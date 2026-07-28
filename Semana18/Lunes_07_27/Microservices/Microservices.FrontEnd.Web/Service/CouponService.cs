using Microservices.FrontEnd.Web.Models;
using Microservices.FrontEnd.Web.Models.CouponDto;
using Microservices.FrontEnd.Web.Service.IService;
using Microservices.FrontEnd.Web.Utility;
using static Microservices.FrontEnd.Web.Utility.SD;

namespace Microservices.FrontEnd.Web.Service
{
    public class CouponService : ICouponService
    {
        private readonly IBaseService _baseService;
        public CouponService(IBaseService baseService)
        {
            _baseService = baseService;
        }

        //POST
        public async Task<ResponseDto?> CreateCouponAsync(CouponDto couponDto)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = ApiType.POST,
                Data = couponDto,
                Url = SD.CouponAPIBase + "/api/CouponsAPI"
            });
        }

        //DELETE
        public async Task<ResponseDto?> DeleteCouponAsync(int id)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = ApiType.DELETE,
                Url = SD.CouponAPIBase + "/api/CouponsAPI/"+id
            });
        }

        public async Task<ResponseDto?> GetAllCouponAsync()
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = ApiType.GET,
                Url = SD.CouponAPIBase + "/api/CouponsAPI"
            });
        }

        public async Task<ResponseDto?> GetCouponByCodeAsync(string couponCode)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = ApiType.GET,
                Url = SD.CouponAPIBase + "/api/CouponsAPI/GetByCode/" + couponCode
            });
        }

        public async Task<ResponseDto?> GetCouponByIdAsync(int id)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = ApiType.GET,
                Url = SD.CouponAPIBase + "/api/CouponsAPI/"+id
            });
        }

        public async Task<ResponseDto?> UpdateCouponAsync(CouponDto couponDto)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = ApiType.PUT,
                Data = couponDto,
                Url = SD.CouponAPIBase + "/api/CouponsAPI"
            });
        }
    }
}
