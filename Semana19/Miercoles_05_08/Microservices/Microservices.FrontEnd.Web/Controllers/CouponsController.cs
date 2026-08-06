using Microservices.FrontEnd.Web.Models;
using Microservices.FrontEnd.Web.Models.CouponDtos;
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
            if (responseDto != null && responseDto.IsSuccess)
            {
                listCoupons = JsonConvert.DeserializeObject<List<CouponDto>>(Convert.ToString(responseDto.Result)!);
            }
            else
            {
                TempData["error"] = responseDto.Message;
            }
            return View(listCoupons);
        }

        #region Post
        [HttpGet]
        public async Task<IActionResult> CouponCreate()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CouponCreate(CouponDto couponDto)
        {
            if (ModelState.IsValid)
            {
                ResponseDto? responseDto = await _couponService.CreateCouponAsync(couponDto);

                if (responseDto != null && responseDto.IsSuccess)
                {
                    TempData["success"] = "Cupon creado existosamente";
                    return RedirectToAction(nameof(CouponIndex));
                }
                else
                {
                    TempData["error"] = responseDto.Message;
                }
            }
            return View(couponDto);
        }
        #endregion

        #region Edit
        [HttpGet]
        public async Task<IActionResult> CouponEdit(int couponId)
        {
            CouponDto couponDto = new();
            ResponseDto? responseDto = await _couponService.GetCouponByIdAsync(couponId);
            if (responseDto != null && responseDto.IsSuccess)
            {
                couponDto = JsonConvert.DeserializeObject<CouponDto>(Convert.ToString(responseDto.Result)!);
                return View(couponDto);
            }
            else
            {
                TempData["error"] = responseDto.Message;
                return View();
            }
        }

        [HttpPost]
        public async Task<IActionResult> CouponEdit(CouponDto couponDto)
        {
            if (ModelState.IsValid)
            {
                ResponseDto? responseDto = await _couponService.UpdateCouponAsync(couponDto);

                if (responseDto != null && responseDto.IsSuccess)
                {
                    TempData["success"] = "Cupon editado existosamente";
                    return RedirectToAction(nameof(CouponIndex));
                }
                else
                {
                    TempData["error"] = responseDto.Message;
                    return View(couponDto);
                }
            }
            return View(couponDto);

        }
        #endregion

        #region Delete
        [HttpGet]
        public async Task<IActionResult> CouponDelete(int couponId)
        {
            CouponDto couponDto = new();
            ResponseDto? responseDto = await _couponService.GetCouponByIdAsync(couponId);
            if (responseDto != null && responseDto.IsSuccess)
            {
                couponDto = JsonConvert.DeserializeObject<CouponDto>(Convert.ToString(responseDto.Result)!);
                return View(couponDto);
            }
            else
            {
                TempData["error"] = responseDto.Message;
                return View();
            }
        }

        [HttpPost]
        public async Task<IActionResult> CouponDelete(CouponDto couponDto)
        {

            ResponseDto? responseDto = await _couponService.DeleteCouponAsync(couponDto.Id);

            if (responseDto != null && responseDto.IsSuccess)
            {
                TempData["success"] = "Cupon eliminado existosamente";
                return RedirectToAction(nameof(CouponIndex));
            }
            else
            {
                TempData["error"] = responseDto.Message;
                return View(couponDto);
            }
            return View(couponDto);

        }
        #endregion

    }
}
