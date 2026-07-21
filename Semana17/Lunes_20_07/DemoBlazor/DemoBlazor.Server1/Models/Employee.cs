namespace DemoBlazor.Server1.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int DepartmentId { get; set; }
        public int Salary { get; set; }
        public DateOnly DateContract { get; set; }
        public virtual Department Department { get; set; } = null;
    }
}
