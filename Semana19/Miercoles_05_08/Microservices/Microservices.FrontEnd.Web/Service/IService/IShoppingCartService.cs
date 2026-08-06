using Microservices.FrontEnd.Web.Models;
using Microservices.FrontEnd.Web.Models.ShoppingCartDto;

namespace Microservices.FrontEnd.Web.Service.IService
{
    public interface IShoppingCartService
    {
        Task<ResponseDto?> GetCartByUserIdAsync(string userId);
        Task<ResponseDto?> UpSertCartAsync(CartDto cartDtoRequest);
        Task<ResponseDto?> RemoveCartAsync(int cartDetailsId);
        Task<ResponseDto?> ApplyCouponAsync(CartDto cartDto);

    }
}
