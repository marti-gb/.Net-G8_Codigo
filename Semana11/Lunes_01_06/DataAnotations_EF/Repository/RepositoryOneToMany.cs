using DataAnotations_EF.Data;
using DataAnotations_EF.Models.OneToMany;
using Microsoft.EntityFrameworkCore;

namespace DataAnotations_EF.Repository
{
    public class RepositoryOneToMany
    {
        private readonly AppDbContext _dbContext;
        public RepositoryOneToMany(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Doctor>> GetDoctors() =>
            await _dbContext.Doctors.ToListAsync();

        public async Task<List<Patient>> GetPatients() =>
            await _dbContext.Patients.Include(x=>x.Doctor).ToListAsync();

        public async Task AddDoctor(Doctor doctor)
        {
            _dbContext.Doctors.Add(doctor);
            await _dbContext.SaveChangesAsync();
        }

        public async Task AddPatient(Patient patient)
        {
            _dbContext.Patients.Add(patient);
            await _dbContext.SaveChangesAsync();
        }
    }
}
