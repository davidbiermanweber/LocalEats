using Microsoft.EntityFrameworkCore;
namespace UserAuthApp.Models
{
    public class AppDbContext : DbContext
    {
        // contructor goes here
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        // DbSet goes here
        public DbSet<User> AppUsers { get; set; }
    }
}