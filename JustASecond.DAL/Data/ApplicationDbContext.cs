using JustASecond.DAL.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace JustASecond.DAL.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<ApplicationUser>? ApplicationUsers { get; set; }
        public DbSet<Order>? Orders { get; set; }
        public DbSet<OrderPosition>? OrderPositions { get; set; }
        public DbSet<Product>? Products { get; set; }
        public DbSet<Table>? Tables { get; set; }
        public DbSet<WaiterOrder>? WaiterOrders { get; set; }
        public DbSet<WaiterCall>? WaiterCalls { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Linked primary key
            builder.Entity<OrderPosition>()
                .HasKey(x => new { x.OrderId, x.Position });

            builder.Entity<WaiterOrder>()
                .HasKey(x => new { x.WaiterId, x.OrderId });

            var user = new ApplicationUser()
            {
                Id = "z65dbe81-22b1-4479-j58g-d730ap050aa1",
                UserName = "admin@justasecond.com",
                NormalizedUserName = "ADMIN@JUSTASECOND.COM",
                Email = "admin@justasecond.com",
                NormalizedEmail = "ADMIN@JUSTASECOND.COM",
                EmailConfirmed = true
            };

            // Generate password hashes
            var hasher = new PasswordHasher<ApplicationUser>();
            user.PasswordHash = hasher.HashPassword(user, "Test1234.");

            builder.Entity<ApplicationUser>().HasData(user);

            var role1 = new IdentityRole()
            {
                Id = "rrrrrrrr-22b1-4479-j58g-rrrrrrrr",
                Name = "Admin",
                NormalizedName = "ADMIN"
            };

            var role2 = new IdentityRole()
            {
                Id = "rrrrrrrr-l0w6-hhhh-jf84-rrrrrrrr",
                Name = "Waiter",
                NormalizedName = "WAITER"
            };

            builder.Entity<IdentityRole>().HasData(role1);
            builder.Entity<IdentityRole>().HasData(role2);

            var userRole1 = new IdentityUserRole<string>()
            {
                RoleId = "rrrrrrrr-22b1-4479-j58g-rrrrrrrr",
                UserId = "z65dbe81-22b1-4479-j58g-d730ap050aa1"
            };

            builder.Entity<IdentityUserRole<string>>().HasData(userRole1);
        }
    }
}