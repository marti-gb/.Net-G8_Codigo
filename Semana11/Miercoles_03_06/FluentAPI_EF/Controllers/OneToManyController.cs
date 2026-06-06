using FluentAPI_EF.Models.OneTOMany;
using FluentAPI_EF.Repository;
using Microsoft.AspNetCore.Mvc;

namespace FluentAPI_EF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OneToManyController : ControllerBase
    {
        private readonly RepositoryOneToMany _repositoryOneToMany;
        public OneToManyController(RepositoryOneToMany repositoryOneToMany)
        {
            _repositoryOneToMany = repositoryOneToMany;
        }

        [HttpGet("Doctors")]
        public async Task<IActionResult> GetDoctorsAsync()
        {
            return Ok(await _repositoryOneToMany.GetDoctorsAsync());
        }

        [HttpGet("Patients")]
        public async Task<IActionResult> GetPatientsAsync()
        {
            return Ok(await _repositoryOneToMany.GetPatientAsync());
        }

        [HttpPost("Doctor")]
        public async Task<IActionResult> AddDoctor(Doctor doctor)
        {
            await _repositoryOneToMany.AddDoctorAsync(doctor);
            return Ok("doctor saved");
        }

        [HttpPost("Patient")]
        public async Task<IActionResult> AddPatient(Patient patient)
        {
            await _repositoryOneToMany.AddPatientAsync(patient);
            return Ok("patient saved");
        }
    }
}
