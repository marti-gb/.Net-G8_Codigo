using System.ComponentModel.DataAnnotations.Schema;

namespace FluentAPI_EF.Models.OneTOOne
{
    public class CarModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int CarCompanyID { get; set; }
        public CarCompany? CarCompany { get; set; }
    }
}
