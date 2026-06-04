using FluentAPI_EF.Data;
using FluentAPI_EF.Models.OneTOOne;
using Microsoft.EntityFrameworkCore;

namespace FluentAPI_EF.Repository
{
    public class RepositoryOneToOne
    {
        private readonly AppDbContext _context;
        public RepositoryOneToOne(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<CarCompany>> GetCompaniesAsync() =>
            await _context.CarCompanies.Include(x=>x.CarModel).ToListAsync();

        public async Task<List<CarModel>> GetCarModelsAsync() =>
            await _context.CarModels.Include(x => x.CarCompany).ToListAsync();

        public async Task AddCarCompanyAsync(CarCompany carCompany)
        {
            _context.CarCompanies.Add(carCompany);
            await _context.SaveChangesAsync();
        }

        public async Task AddCarCModelAsync(CarModel carModel)
        {
            _context.CarModels.Add(carModel);
            await _context.SaveChangesAsync();
        }
    }
}
