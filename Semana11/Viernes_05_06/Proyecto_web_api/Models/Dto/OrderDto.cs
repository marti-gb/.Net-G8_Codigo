using Proyecto_web_api.Models.OneToMany;

namespace Proyecto_web_api.Models.Dto
{
    public class OrderDto
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public DateTime OrderDate { get; set; }
        public List<OrderDetailDto>? OrderDetailsDto { get; set; }

    }
}
