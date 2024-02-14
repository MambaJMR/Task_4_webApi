using System.ComponentModel.DataAnnotations;

namespace Task_4_webApi.Models.Dto
{
    public class RegisterModel
    {
        public string Email { get; set; } = string.Empty;

        public string? Name { get; set; }
        public DateTime RegisterDate { get; set; } = DateTime.Now;
        public string Password { get; set; } = string.Empty;
    }
}
