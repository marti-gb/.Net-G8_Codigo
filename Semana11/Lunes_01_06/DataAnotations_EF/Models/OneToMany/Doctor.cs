using System.Text.Json.Serialization;

namespace DataAnotations_EF.Models.OneToMany
{
    public class Doctor
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public ICollection<Patient>? Patients { get; set; }
    }
}
