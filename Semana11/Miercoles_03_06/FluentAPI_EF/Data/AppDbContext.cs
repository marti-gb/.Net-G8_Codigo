using FluentAPI_EF.Models.OneTOOne;
using Microsoft.EntityFrameworkCore;

namespace FluentAPI_EF.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {
        }

        public DbSet<CarCompany> CarCompanies { get; set; }
        public DbSet<CarModel> CarModels { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //One TO One
            modelBuilder.Entity<CarCompany>()
                .HasOne(x => x.CarModel)
                .WithOne(r => r.CarCompany)
                .HasForeignKey<CarModel>(z => z.CarCompanyID)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
