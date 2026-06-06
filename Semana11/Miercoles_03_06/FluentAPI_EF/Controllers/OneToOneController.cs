using FluentAPI_EF.Models.OneTOOne;
using FluentAPI_EF.Repository;
using Microsoft.AspNetCore.Mvc;

namespace FluentAPI_EF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OneToOneController : ControllerBase
    {
        private readonly RepositoryOneToOne _repositoryOneToOne;
        public OneToOneController(RepositoryOneToOne repositoryOneToOne)
        {
            _repositoryOneToOne = repositoryOneToOne;
        }

        [HttpGet("CarCompanies")]
        public async Task<IActionResult> GetCarCompaniesAsync()
        {
            return Ok(await _repositoryOneToOne.GetCompaniesAsync());
        }

        [HttpGet("CarModels")]
        public async Task<IActionResult> GetCarModelsAsync()
        {
            return Ok(await _repositoryOneToOne.GetCarModelsAsync());
        }

        [HttpPost("CarCompany")]
        public async Task<IActionResult> AddCarCompany(CarCompany carCompany)
        {
            await _repositoryOneToOne.AddCarCompanyAsync(carCompany);
            return Ok("company saved");
        }

        [HttpPost("CarModel")]
        public async Task<IActionResult> AddCarModel(CarModel carModel)
        {
            await _repositoryOneToOne.AddCarCModelAsync(carModel);
            return Ok("car model saved");
        }

    }
}
