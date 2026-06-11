namespace CRUD_MVC.Models.OneToMany
{
    public class Doctor
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public bool IsDeleted { get; set; } = false;
        public List<Patient>? ListPatients { get; set; } = new List<Patient>();
    }
}
