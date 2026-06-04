namespace FluentAPI_EF.Models.OneTOOne
{
    public class CarCompany
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public CarModel? CarModel { get; set; }
    }
}
