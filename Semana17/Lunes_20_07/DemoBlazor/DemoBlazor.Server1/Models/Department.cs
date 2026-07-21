namespace DemoBlazor.Server1.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsDeleted { get; set; } = false;
        public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
    }
}
