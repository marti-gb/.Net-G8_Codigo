using System.Text.Json.Serialization;

namespace DataAnotations_EF.Models.ManyToMany
{
    public class Student
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        [JsonIgnore]
        public ICollection<Course>? Course { get; set; }
    }
}
