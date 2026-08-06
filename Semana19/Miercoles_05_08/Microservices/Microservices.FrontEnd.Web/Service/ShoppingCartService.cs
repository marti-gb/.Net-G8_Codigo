using Microservices.FrontEnd.Web.Models;
using Microservices.FrontEnd.Web.Models.ShoppingCartDto;
using Microservices.FrontEnd.Web.Service.IService;
using Microservices.FrontEnd.Web.Utility;
using static Microservices.FrontEnd.Web.Utility.SD;

namespace Microservices.FrontEnd.Web.Service
{
    public class ShoppingCartService : IShoppingCartService
    {
        private readonly IBaseService _baseService;
        public ShoppingCartService(IBaseService baseService)
        {
            _baseService = baseService;
        }

        public async Task<ResponseDto?> GetCartByUserIdAsync(string userId)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = ApiType.GET,
                Url = SD.ShoppingCartAPIBase + "/api/ShoppingCartAPI/GetCart/"+userId
            });
        }

        public async Task<ResponseDto?> UpSertCartAsync(CartDto cartDtoRequest)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = ApiType.POST,
                Data = cartDtoRequest,
                Url = SD.ShoppingCartAPIBase + "/api/ShoppingCartAPI/UpSert"
            });
        }

        public async Task<ResponseDto?> RemoveCartAsync(int cartDetailsId)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = ApiType.POST,
                Data = cartDetailsId,
                Url = SD.ShoppingCartAPIBase + "/api/ShoppingCartAPI/RemoveCart"
            });
        }

        public async Task<ResponseDto?> ApplyCouponAsync(CartDto cartDto)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = ApiType.POST,
                Data = cartDto,
                Url = SD.ShoppingCartAPIBase + "/api/ShoppingCartAPI/ApplyCoupon"
            });
        }

    }
}
