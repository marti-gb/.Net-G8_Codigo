using FluentAPI_EF.Models.ManyToMany;
using FluentAPI_EF.Models.ManyTOMany;
using FluentAPI_EF.Repository;
using Microsoft.AspNetCore.Mvc;

namespace FluentAPI_EF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManyToManyController : ControllerBase
    {
        private readonly RepositoryManyToMany _repositoryManyToMany;
        public ManyToManyController(RepositoryManyToMany repositoryManyToMany)
        {
            _repositoryManyToMany = repositoryManyToMany;
        }

        [HttpGet("Students")]
        public async Task<IActionResult> GetStudentsAsync()
        {
            return Ok(await _repositoryManyToMany.GetStudentsAsync());
        }

        [HttpGet("Courses")]
        public async Task<IActionResult> GetCoursesAsync()
        {
            return Ok(await _repositoryManyToMany.GetCourseAsync());
        }

        [HttpGet("StudentCourses")]
        public async Task<IActionResult> GetStudentCoursesAsync()
        {
            return Ok(await _repositoryManyToMany.GetStudentCourses());
        }

        [HttpPost("Student")]
        public async Task<IActionResult> AddStudent(Student student)
        {
            await _repositoryManyToMany.AddStudentAsync(student);
            return Ok("student saved");
        }

        [HttpPost("Course")]
        public async Task<IActionResult> AddCourse(Course course)
        {
            await _repositoryManyToMany.AddCourseAsync(course);
            return Ok("course saved");
        }

        [HttpPost("StudentCourse")]
        public async Task<IActionResult> AddStudentCourse(int studentId, int courseId)
        {
            await _repositoryManyToMany.AddStudentCourse(studentId, courseId);
            return Ok("student course saved");
        }
    }
}
