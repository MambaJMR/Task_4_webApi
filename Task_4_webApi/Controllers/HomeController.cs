using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Task_4_webApi.Data;

namespace Task_4_webApi.Controllers
{
    [ApiController]
    [Authorize]
    public class HomeController : ControllerBase
    {
        private readonly AppDbContext _db;
        public HomeController(AppDbContext db)
        {
            _db = db;
        }

        [Route("/Users")]
        public async Task<IActionResult> Users()
        {
            var users = await _db.Users.ToListAsync();
            return Ok(users);
        }

        [Route("/Delete")]

        public async Task<IActionResult> Delete([FromBody]int[] userIds)
        {
            foreach (var id in userIds)
            {
                var user = await _db.Users.FirstOrDefaultAsync(u => u.Id == id);
                if (user != null)
                {
                     _db.Users.Remove(user);
                    await _db.SaveChangesAsync();
                }

            }
            return Ok();
        }

        [Route("/Block")]
        public async Task<IActionResult> Block([FromBody]int[] userIds)
        {
            foreach (var id in userIds)
            {
                var user = await _db.Users.FirstOrDefaultAsync(u => u.Id == id);
                if (user != null)
                {
                    user.IsBloked = true;
                    await _db.SaveChangesAsync();
                    if (HttpContext.User.Identity.Name == user.Email)
                    {
                        return RedirectToAction("logout", "Account");
                    }
                }
            }
            return Ok();
        }


        [Route("/UnBlock")]
        public async Task<IActionResult> UnBlock([FromBody] int[] userIds)
        {
            foreach (var id in userIds)
            {
                var user = await _db.Users.FirstOrDefaultAsync(u => u.Id == id);
                if (user != null)
                {
                    user.IsBloked = false;
                    await _db.SaveChangesAsync();
                }
                else
                {
                    return NotFound();
                }
            }
            return Ok();
        }

    }
}
