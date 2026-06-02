using DataAnotations_EF.Data;
using DataAnotations_EF.Models.OneToOne;
using Microsoft.EntityFrameworkCore;

namespace DataAnotations_EF.Repository
{
    public class RepositoryOneTOOne
    {
        private readonly AppDbContext _dbContext;
        public RepositoryOneTOOne(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<CarCompany>> GetCarCompanies() =>
            await _dbContext.CarCompanies.ToListAsync();

        public async Task<List<CarModel>> GetCarModels() =>
            await _dbContext.CarModels.ToListAsync();

        public async Task AddCarCompany(CarCompany carCompany)
        {
            _dbContext.CarCompanies.Add(carCompany);
            await _dbContext.SaveChangesAsync();
        }

        public async Task AddCarModel(CarModel carModel)
        {
            _dbContext.CarModels.Add(carModel);
            await _dbContext.SaveChangesAsync();
        }


    }
}
