using Microservices.BackEnd.CouponAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace Microservices.BackEnd.CouponAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Coupon> Coupons { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Coupon>().HasData(new Coupon
            {
                Id = 1,
                CouponCode = "10OFF",
                DiscountAmount = 10,
                MinimunAmount = 20,
                IsDeleted = false,
            });

            modelBuilder.Entity<Coupon>().HasData(new Coupon
            {
                Id = 2,
                CouponCode = "20OFF",
                DiscountAmount = 20,
                MinimunAmount = 40,
                IsDeleted = false,
            });
        }
    }
}
