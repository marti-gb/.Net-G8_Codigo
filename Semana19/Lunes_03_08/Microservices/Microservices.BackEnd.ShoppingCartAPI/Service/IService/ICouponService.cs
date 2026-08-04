using Microservices.BackEnd.ShoppingCartAPI.Models.Dto;

namespace Microservices.BackEnd.ShoppingCartAPI.Service.IService
{
    public interface ICouponService
    {
        Task<CouponDto> GetCouponByCodeAsync(string couponCode);
    }
}
