using System.Text.Json.Serialization;

namespace Proyecto_web_api.Models.OneToMany
{
    public class Order
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public DateTime OrderDate { get; set; }

        [JsonIgnore]
        public IEnumerable<OrderDetail>? OrderDetails { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
