using JustASecond.Web.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace JustASecond.Web.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<ApplicationUser>? Users { get; set; }
        public DbSet<Customer>? Customers { get; set; }
        public DbSet<Order>? Orders { get; set; }
        public DbSet<OrderPosition>? OrderPositions { get; set; }
        public DbSet<Product>? Products { get; set; }
        public DbSet<Product>? Tables { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Linked primary key
            builder.Entity<OrderPosition>()
                .HasKey(x => new { x.OrderId, x.Position });
        }
    }
}