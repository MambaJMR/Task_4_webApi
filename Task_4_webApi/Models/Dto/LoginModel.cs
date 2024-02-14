using System.ComponentModel.DataAnnotations;

namespace Task_4_webApi.Models.Dto
{
    public class LoginModel
    { 
        public string Email { get; set; } = string.Empty;

        public DateTime LastLoginDate { get; set; } = DateTime.Now;
        public string Password { get; set; } = string.Empty;
    }
}
