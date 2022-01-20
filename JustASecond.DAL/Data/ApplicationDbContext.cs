using JustASecond.DAL.Data.Models;
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
        }
    }
}