using System.ComponentModel.DataAnnotations;

namespace DemoBlazor.Shared
{
    public class EmployeeDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string Name { get; set; }

        [Range(0, int.MaxValue)]
        public int DepartmentId { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [Range(0, int.MaxValue)]
        public int Salary { get; set; }
        public DateOnly DateContract { get; set; }
        public virtual DepartmentDto? DepartmentDto { get; set; } 
    }
}
