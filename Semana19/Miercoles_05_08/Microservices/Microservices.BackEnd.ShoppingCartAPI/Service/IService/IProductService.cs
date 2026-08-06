using Microservices.BackEnd.ShoppingCartAPI.Models.Dto;

namespace Microservices.BackEnd.ShoppingCartAPI.Service.IService
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GetProductsAsync();
    }
}
