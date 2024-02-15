using System.ComponentModel.DataAnnotations;

namespace Task_4_webApi.Models
{
    public class User
    {
        public int Id { get; set; }
        [StringLength(20)]
        public string Name { get; set; } = string.Empty;
        [StringLength(50)]
        public string? Email { get; set; }
        [StringLength(20)]
        public string Password { get; set; } = string.Empty;
        public bool IsBloked { get; set; } = false;
        public DateTime RegsitrationDate { get; set; }
        public DateTime LastLoginDate { get; set; }
    }
}
