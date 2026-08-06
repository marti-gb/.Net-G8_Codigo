namespace Microservices.FrontEnd.Web.Models.ShoppingCartDto
{
    public class CartDto
    {
        public CartHeaderDto CartHeaderDto { get; set; }
        public IEnumerable<CartDetailsDto>? cartDetailsDtos { get; set; }
    }
}
