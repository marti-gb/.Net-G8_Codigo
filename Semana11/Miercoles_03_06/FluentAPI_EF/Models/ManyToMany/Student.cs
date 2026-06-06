using FluentAPI_EF.Models.ManyToMany;
using System.Text.Json.Serialization;

namespace FluentAPI_EF.Models.ManyTOMany
{
    public class Student
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        [JsonIgnore]
        public ICollection<StudentCourse>? StudentCourses { get; set; }
    }
}
