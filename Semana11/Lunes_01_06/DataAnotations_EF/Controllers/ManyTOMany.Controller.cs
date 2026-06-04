using DataAnotations_EF.Models.ManyToMany;
using DataAnotations_EF.Repository;
using Microsoft.AspNetCore.Mvc;

namespace DataAnotations_EF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManyTOManyController : ControllerBase
    {
        private readonly RepositoryManyTOMany _repositoryManyTOMany;

        public ManyTOManyController(RepositoryManyTOMany repositoryManyTOMany)
        {
            _repositoryManyTOMany = repositoryManyTOMany;
        }

        [HttpGet("Students")]
        public async Task<IActionResult> GetStudents()
        {
            return Ok(await _repositoryManyTOMany.GetStudents());
        }

        [HttpGet("Courses")]
        public async Task<IActionResult> GetCourses()
        {
            return Ok(await _repositoryManyTOMany.GetCourses());
        }

        [HttpPost("Student")]
        public async Task<IActionResult> AddStudent(Student student)
        {
            await _repositoryManyTOMany.AddStudent(student);
            return Ok(student);
        }

        [HttpPost("Course")]
        public async Task<IActionResult> AddCourse(Course course)
        {
            await _repositoryManyTOMany.AddCourse(course);
            return Ok(course);
        }

        [HttpPost("AsignarEstudianteACurso")]
        public async Task<IActionResult> AssignStudentToCourse(int studentId, int courseId)
        {
            try
            {
                await _repositoryManyTOMany.AssignStudentToCourse(studentId, courseId);
                return Ok(new
                {
                    message = $"Estudiante {studentId} asignado al curso {courseId} exitosamente",
                    studentId = studentId,
                    courseId = courseId
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }


        [HttpPost("EstudianteConCursos")]
        public async Task<IActionResult> AddStudentWithCourses([FromBody] Student student, [FromQuery] List<int> courseIds)
        {
            try
            {
                await _repositoryManyTOMany.AddStudentWithCourses(student, courseIds);
                return Ok(new
                {
                    message = "Estudiante creado y asignado a cursos exitosamente",
                    student = student,
                    courseIds = courseIds
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        [HttpPost("CusoConEstudiantes")]
        public async Task<IActionResult> AddCourseWithStudents([FromBody] Course course, [FromQuery] List<int> studentIds)
        {
            try
            {
                await _repositoryManyTOMany.AddCourseWithStudents(course, studentIds);
                return Ok(new
                {
                    message = "Curso creado y asignado a estudiantes exitosamente",
                    course = course,
                    studentIds = studentIds
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        [HttpGet("EstudiantesConCursosResumen")]
        public async Task<IActionResult> GetStudentsWithCoursesSummary()
        {
            var result = await _repositoryManyTOMany.GetStudentsWithCoursesSummary();
            return Ok(result);
        }

        [HttpGet("CursoConEstudiantesResumen")]
        public async Task<IActionResult> GetCoursesWithStudentsSummary()
        {
            var result = await _repositoryManyTOMany.GetCourseStudentSummary();
            return Ok(result);
        }
    }
}
