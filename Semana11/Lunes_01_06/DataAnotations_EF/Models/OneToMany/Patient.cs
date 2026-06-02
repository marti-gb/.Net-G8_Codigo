using System.Text.Json.Serialization;

namespace DataAnotations_EF.Models.OneToMany
{
    public class Patient
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int DoctorId { get; set; }
        [JsonIgnore]
        public virtual Doctor? Doctor { get; set; }
    }
}
