using Microsoft.AspNetCore.Mvc;
using Task_4_webApi.Data;
using Task_4_webApi.Models.Dto;
using Task_4_webApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;

namespace Task_4_webApi.Controllers
{
    public class AccountController : ControllerBase
    {
        private readonly AppDbContext _db;
        public AccountController(AppDbContext db)
        {
            _db = db;
        }

        [Route("/Login")]
        [HttpPost]
        public async Task<IActionResult> Login([FromBody]LoginModel model)
        {
            var user = await _db.Users.FirstOrDefaultAsync(u => u.Email == model.Email && u.Password == model.Password);
            if (user != null && user.IsBloked != true)
            {
                user.LastLoginDate = DateTime.UtcNow;
                await _db.SaveChangesAsync();
                await Authenticate(model.Email);
                return Ok();
            }
            return NotFound();
        }

        [Route("/Register")]
        [HttpPost]
        public async Task<IActionResult> Register([FromBody]RegisterModel model)
        {
           
                User? user = await _db.Users.FirstOrDefaultAsync(u => u.Email == model.Email);
                if (user == null)
                {
                    _db.Users.Add(new User { Email = model.Email, Password = model.Password, Name = model.Name, RegsitrationDate = DateTime.Now});
                    await _db.SaveChangesAsync();

                    await Authenticate(model.Email);

                    return Ok();
                }
            return NotFound();
        }

        private async Task Authenticate(string userName)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, userName)
            };
            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }
        [Route("/logout")]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Redirect("/Login.html");
        }
    }
}
