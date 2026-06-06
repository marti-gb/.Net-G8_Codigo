using Proyecto_web_api.Models.OneToMany;

namespace Proyecto_web_api.Models.Dto
{
    public class OrderDetailDto
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public OrderDto? OrderDto { get; set; }
        public int? Quantity { get; set; }
        public decimal? Price { get; set; }
    }
}
