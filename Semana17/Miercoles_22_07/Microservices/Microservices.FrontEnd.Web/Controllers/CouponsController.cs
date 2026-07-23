using Microservices.FrontEnd.Web.Models;
using Microservices.FrontEnd.Web.Models.CouponDto;
using Microservices.FrontEnd.Web.Service.IService;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Microservices.FrontEnd.Web.Controllers
{
    public class CouponsController : Controller
    {
        private readonly ICouponService _couponService;
        public CouponsController(ICouponService couponService)
        {
            _couponService = couponService;
        }

        [HttpGet]
        public async Task<IActionResult> CouponIndex()
        {
            List<CouponDto>? listCoupons = new();
            ResponseDto? responseDto = await _couponService.GetAllCouponAsync();
            if(responseDto != null && responseDto.IsSuccess)
            {
                listCoupons = JsonConvert.DeserializeObject<List<CouponDto>>(Convert.ToString(responseDto.Result)!);
            }
            else
            {
                TempData["error"] = responseDto.Message;
            }
            return View(listCoupons);
        } 

    }
}
