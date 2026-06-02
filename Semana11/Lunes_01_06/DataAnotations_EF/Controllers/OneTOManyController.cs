using DataAnotations_EF.Models.OneToMany;
using DataAnotations_EF.Repository;
using Microsoft.AspNetCore.Mvc;


namespace DataAnotations_EF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OneTOManyController : ControllerBase
    {
        private readonly RepositoryOneToMany _repositoryOneToMany;

        public OneTOManyController(RepositoryOneToMany repositoryOneToMany)
        {
            _repositoryOneToMany = repositoryOneToMany;
        }

        //One TO One
        [HttpGet("Doctors")]
        public async Task<IActionResult> GetDoctors()
        {
            return Ok(await _repositoryOneToMany.GetDoctors());
        }

        [HttpGet("Patients")]
        public async Task<IActionResult> GetCPatients()
        {
            return Ok(await _repositoryOneToMany.GetPatients());
        }

        [HttpPost("Doctor")]
        public async Task<IActionResult> AddDoctor(Doctor doctor)
        {
            await _repositoryOneToMany.AddDoctor(doctor);
            return Ok(doctor);
        }
        [HttpPost("Patient")]
        public async Task<IActionResult> AddPatient(Patient patient)
        {
            await _repositoryOneToMany.AddPatient(patient);
            return Ok(patient);
        }
    }
}
