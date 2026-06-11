namespace CRUD_MVC.Models.OneToMany
{
    public class Doctor
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public List<Patient>? ListPatients { get; set; } = new List<Patient>();
    }
}
