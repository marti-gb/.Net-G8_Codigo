using System.ComponentModel.DataAnnotations.Schema;

namespace DataAnotations_EF.Models.OneToOne
{
    public class CarModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        //[ForeignKey("CarCompany")]
        public int CarCompanyId { get; set; }
        public virtual CarCompany? CarCompany { get; set; }
    }
}
