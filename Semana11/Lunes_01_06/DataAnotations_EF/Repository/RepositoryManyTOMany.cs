using DataAnotations_EF.Data;
using DataAnotations_EF.Models.ManyToMany;
using Microsoft.EntityFrameworkCore;

namespace DataAnotations_EF.Repository
{
    public class RepositoryManyTOMany
    {
        private readonly AppDbContext _dbContext;
        public RepositoryManyTOMany(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Student>> GetStudents() =>
            await _dbContext.Students.Include(x => x.Course).ToListAsync();

        public async Task<List<Course>> GetCourses() =>
            await _dbContext.Courses.Include(x => x.Students).ToListAsync();

        public async Task AddStudent(Student student)
        {
            _dbContext.Students.Add(student);
            await _dbContext.SaveChangesAsync();
        }

        public async Task AddCourse(Course course)
        {
            _dbContext.Courses.Add(course);
            await _dbContext.SaveChangesAsync();
        }

        // Asociar un estudiante existente a un curso existente
        //from Students join Course join CourseStudent where course
        public async Task AssignStudentToCourse(int studentId, int courseId)
        {
            var student = await _dbContext.Students 
                .Include(s => s.Course)
                .FirstOrDefaultAsync(s => s.Id == studentId);

            var course = await _dbContext.Courses
                .Include(c => c.Students)
                .FirstOrDefaultAsync(c => c.Id == courseId);

            if (student == null || course == null)
                throw new Exception("Estudiante o curso no encontrado");

            if (student.Course == null)
                student.Course = new HashSet<Course>();

            student.Course.Add(course);

            //_dbContext.CourseStudent.Add(studentId, courseId);

            await _dbContext.SaveChangesAsync();
        }

        // Crear estudiante y asociarlo a cursos existentes
        public async Task AddStudentWithCourses(Student student, List<int> courseIds)
        {
            if (courseIds != null && courseIds.Any())
            {
                var courses = await _dbContext.Courses
                    .Where(c => courseIds.Contains(c.Id))
                    .ToListAsync();

                student.Course = courses;
            }

            _dbContext.Students.Add(student);
            await _dbContext.SaveChangesAsync();
        }

        // Crear curso y asociarlo a estudiantes existentes
        public async Task AddCourseWithStudents(Course course, List<int> studentIds)
        {
            if (studentIds != null && studentIds.Any())
            {
                var students = await _dbContext.Students
                    .Where(s => studentIds.Contains(s.Id))
                    .ToListAsync();

                course.Students = students;
            }

            _dbContext.Courses.Add(course);
            await _dbContext.SaveChangesAsync();
        }

        // Obtener todos los estudiantes con sus cursos
        public async Task<List<object>> GetStudentsWithCoursesSummary()
        {
            var students = await _dbContext.Students
                .Select(s => new
                {
                    StudentId = s.Id,
                    StudentName = s.Name,
                    Courses = s.Course != null && s.Course.Any()
                        ? s.Course.Select(c => new
                        {
                            CourseId = c.Id,
                            CourseName = c.Name
                        }).ToList<object>()
                        : new List<object>()
                })
                .ToListAsync();

            return students.Cast<object>().ToList();
        }

        // Obtener todos los cursos con sus estudiantes
        public async Task<List<object>> GetCourseStudentSummary()
        {
            var courses = await _dbContext.Courses
                .Select(c => new
                {
                    CourseId = c.Id,
                    CourseName = c.Name,
                    Students = c.Students != null && c.Students.Any()
                        ? c.Students.Select(s => new
                        {
                            StudentId = s.Id,
                            StudentName = s.Name
                        }).ToList<object>()
                        : new List<object>()
                })
                .ToListAsync();

            return courses.Cast<object>().ToList();
        }
    }
}
