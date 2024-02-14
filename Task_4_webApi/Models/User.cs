namespace Task_4_webApi.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Email { get; set; }
        public string Password { get; set; } = string.Empty;
        public bool IsBloked { get; set; } = false;
        public DateTime RegsitrationDate { get; set; }
        public DateTime LastLoginDate { get; set; }
    }
}
