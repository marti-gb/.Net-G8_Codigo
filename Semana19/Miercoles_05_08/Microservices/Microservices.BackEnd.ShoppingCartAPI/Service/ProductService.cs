using Microservices.BackEnd.ShoppingCartAPI.Models.Dto;
using Microservices.BackEnd.ShoppingCartAPI.Service.IService;
using Newtonsoft.Json;

namespace Microservices.BackEnd.ShoppingCartAPI.Service
{
    public class ProductService : IProductService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public ProductService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IEnumerable<ProductDto>> GetProductsAsync()
        {
            var client = _httpClientFactory.CreateClient("Products");
            var response = await client.GetAsync($"/api/ProductsAPI");

            var apiContent = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<ResponseDto>(apiContent);
            if (result != null && result.IsSuccess)
            {
                return JsonConvert.DeserializeObject<IEnumerable<ProductDto>>(Convert.ToString(result.Result)!)!;
            }

            return new List<ProductDto>();
        }
    }
}
