using System.ComponentModel.DataAnnotations;

namespace DataAnotations_EF.Models.OneToOne
{
    public class CarCompany
    {
        //[Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public virtual CarModel? CarModel { get; set; }
    }
}
