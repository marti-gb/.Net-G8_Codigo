using FluentAPI_EF.Data;
using FluentAPI_EF.Models.ManyToMany;
using FluentAPI_EF.Models.ManyTOMany;
using FluentAPI_EF.Models.OneTOMany;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace FluentAPI_EF.Repository
{
    public class RepositoryManyToMany
    {
        private readonly AppDbContext _context;
        public RepositoryManyToMany(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Student>> GetStudentsAsync() =>
            await _context.Students.Include(x => x.StudentCourses).ToListAsync();

        public async Task<List<Course>> GetCourseAsync() =>
            await _context.Courses.Include(x => x.StudentCourses).ToListAsync();

        public async Task AddStudentAsync(Student student)
        {
            await _context.Students.AddAsync(student);
            await _context.SaveChangesAsync();
        }

        public async Task AddCourseAsync(Course course)
        {
            await _context.Courses.AddAsync(course);
            await _context.SaveChangesAsync();
        }

        public async Task AddStudentCourse(int studentId, int courseId)
        {
            await _context.StudentCourses.AddAsync(new StudentCourse()
            {
                StudentId = studentId,
                CourseId = courseId
            });
            await _context.SaveChangesAsync();
        }

        public async Task<List<StudentCourse>> GetStudentCourses() =>
            await _context.StudentCourses
            .Include(v=>v.Student)
            .Include(v=>v.Course)
            .ToListAsync();
    }
}
