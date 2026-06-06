using FluentAPI_EF.Models.ManyToMany;
using FluentAPI_EF.Models.ManyTOMany;
using FluentAPI_EF.Models.OneTOMany;
using FluentAPI_EF.Models.OneTOOne;
using Microsoft.EntityFrameworkCore;

namespace FluentAPI_EF.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {
        }

        //One To One
        public DbSet<CarCompany> CarCompanies { get; set; }
        public DbSet<CarModel> CarModels { get; set; }

        //One To Many
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Patient> Patients { get; set; }

        //Many To Many
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<StudentCourse> StudentCourses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //One TO One
            modelBuilder.Entity<CarCompany>()
                .HasOne(x => x.CarModel)
                .WithOne(r => r.CarCompany)
                .HasForeignKey<CarModel>(z => z.CarCompanyID)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            //One To Many
            modelBuilder.Entity<Doctor>()
                .HasMany(x=>x.Patients)
                .WithOne(p=>p.Doctor)
                .HasForeignKey(x=>x.DoctorId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            //Many To Many
            modelBuilder.Entity<StudentCourse>()
                .HasKey(z => new { z.StudentId, z.CourseId });
            modelBuilder.Entity<StudentCourse>()
                .HasOne(p=>p.Student)
                .WithMany(x=>x.StudentCourses)
                .HasForeignKey(y=>y.StudentId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<StudentCourse>()
                .HasOne(p => p.Course)
                .WithMany(x => x.StudentCourses)
                .HasForeignKey(y => y.CourseId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
