using Microsoft.EntityFrameworkCore;
namespace UserAuthApp.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> AppUsers { get; set; }

        public DbSet<MenuItem> MenuItem {get; set;}

        public DbSet<MenuCategory> MenuCategory {get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("app_users");
            modelBuilder.Entity<MenuItem>().ToTable("menu_item");
            modelBuilder.Entity<MenuCategory>().ToTable("menu_category");
        }
    }
}