using System.ComponentModel.DataAnnotations;

namespace DataBaseFirst.Data
{
    public class Usuario
    {
        public int Id { get; set; }

        [StringLength(200)]
        public string Name { get; set; } = string.Empty;
        public bool? IsDeleted {  get; set; }
    }
}
