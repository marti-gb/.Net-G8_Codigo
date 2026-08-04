using Microservices.BackEnd.ShoppingCartAPI.Models.Dto;
using Microservices.BackEnd.ShoppingCartAPI.Service.IService;
using Newtonsoft.Json;

namespace Microservices.BackEnd.ShoppingCartAPI.Service
{
    public class CouponService : ICouponService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public CouponService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<CouponDto> GetCouponAsync(string couponCode)
        {
            var client = _httpClientFactory.CreateClient("Coupon");
            var response = await client.GetAsync($"/api/CouponsAPI/GetByCode/{couponCode}");

            var apiContent = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<ResponseDto>(Convert.ToString(apiContent));
            if(result != null && result.IsSuccess)
            {
                return JsonConvert.DeserializeObject<CouponDto>(Convert.ToString(result.Result)!)!;
            }

            return new CouponDto();
        }
    }
}
