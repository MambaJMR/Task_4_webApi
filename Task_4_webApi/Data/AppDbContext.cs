using Microsoft.EntityFrameworkCore;
using Task_4_webApi.Models;

namespace Task_4_webApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<User> Users { get; set; }
    }
}
