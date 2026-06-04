using System.Text.Json.Serialization;

namespace DataAnotations_EF.Models.ManyToMany
{
    public class Course
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        [JsonIgnore]
        public IEnumerable<Student>? Students { get; set; }
    }
}
