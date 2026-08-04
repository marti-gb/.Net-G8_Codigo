using Microservices.FrontEnd.Web.Models;
using Microservices.FrontEnd.Web.Models.ProductDto;

namespace Microservices.FrontEnd.Web.Service.IService
{
    public interface IProductService
    {
        Task<ResponseDto?> GetAllProductAsync();
        Task<ResponseDto?> GetProductByIdAsync(int id);
        Task<ResponseDto?> CreateProductAsync(ProductDto productDto);
        Task<ResponseDto?> UpdateProductAsync(ProductDto productDto);
        Task<ResponseDto?> DeleteProductAsync(int id);

    }
}
