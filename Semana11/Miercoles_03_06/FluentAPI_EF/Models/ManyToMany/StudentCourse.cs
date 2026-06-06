using FluentAPI_EF.Models.ManyTOMany;

namespace FluentAPI_EF.Models.ManyToMany
{
    public class StudentCourse
    {
        public int StudentId { get; set; }
        public int CourseId { get; set; }
        public Student? Student { get; set; }
        public Course? Course { get; set; }

    }
}
