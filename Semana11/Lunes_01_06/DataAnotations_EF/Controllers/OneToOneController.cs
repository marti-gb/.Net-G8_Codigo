using DataAnotations_EF.Models.OneToOne;
using DataAnotations_EF.Repository;
using Microsoft.AspNetCore.Mvc;

namespace DataAnotations_EF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OneToOneController : ControllerBase
    {
        private readonly RepositoryOneTOOne _repositoryOneTOOne;

        public OneToOneController(RepositoryOneTOOne repositoryOneTOOne)
        {
            _repositoryOneTOOne = repositoryOneTOOne;
        }

        //One TO One
        [HttpGet("CarCompany")]
        public async Task<IActionResult> GetCarCompanies()
        {
            return Ok(await _repositoryOneTOOne.GetCarCompanies());
        }

        [HttpGet("CarModel")]
        public async Task<IActionResult> GetCarModels()
        {
            return Ok(await _repositoryOneTOOne.GetCarModels());
        }

        [HttpPost("CarCompany")]
        public async Task<IActionResult> AddCarCompany(CarCompany carCompany)
        {
            await _repositoryOneTOOne.AddCarCompany(carCompany);
            return Ok(carCompany);
        }
        [HttpPost("CarModel")]
        public async Task<IActionResult> AddCarModel(CarModel carModel)
        {
            await _repositoryOneTOOne.AddCarModel(carModel);
            return Ok(carModel);
        }
    }
}
