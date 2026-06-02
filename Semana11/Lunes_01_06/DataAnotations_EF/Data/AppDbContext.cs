using DataAnotations_EF.Models.OneToMany;
using DataAnotations_EF.Models.OneToOne;
using Microsoft.EntityFrameworkCore;

namespace DataAnotations_EF.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        //One TO One
        public DbSet<CarModel> CarModels { get; set; }
        public DbSet<CarCompany> CarCompanies { get; set; }

        //OneToMany
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Patient> Patients { get; set; }
    }
}
