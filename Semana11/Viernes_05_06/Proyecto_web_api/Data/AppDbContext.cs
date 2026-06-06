using Microsoft.EntityFrameworkCore;
using Proyecto_web_api.Models.OneToMany;

namespace Proyecto_web_api.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>()
            .HasMany(p => p.OrderDetails)
            .WithOne(x => x.Order)
            .HasForeignKey(x => x.OrderId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);
                
        }
    }
}
