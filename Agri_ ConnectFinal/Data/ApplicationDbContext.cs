using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Agri__ConnectFinal.Models;

namespace Agri__ConnectFinal
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public DbSet<CartDetail> CartDetails { get; set; }
        public DbSet<Grocery> Groceries { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Vegetable> Vegetables { get; set; }
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<Farmer> Farmers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Grocery>()
                .HasOne(g => g.Farmer)
                .WithMany(f => f.Groceries)
                .HasForeignKey(g => g.FarmerId);

            // Customize other model configurations here if needed
        }
    }
}
