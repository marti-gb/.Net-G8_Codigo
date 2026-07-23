using AutoMapper;
using Microservices.BackEnd.CouponAPI.Data;
using Microservices.BackEnd.CouponAPI.Models;
using Microservices.BackEnd.CouponAPI.Models.Dto;
using Microsoft.AspNetCore.Mvc;

namespace Microservices.BackEnd.CouponAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CouponsController : ControllerBase
    {
        private readonly ApplicationDbContext _db;
        private ResponseDto _responseDto;
        private readonly IMapper _mapper;
        public CouponsController(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _responseDto = new ResponseDto();
            _mapper = mapper;
        }

        [HttpGet]
        public ResponseDto GetAll()
        {
            try
            {
                IEnumerable<Coupon> couponList = _db.Coupons.Where(x=>!x.IsDeleted).ToList();
                _responseDto.Result = _mapper.Map<IEnumerable<CouponDto>>(couponList);
                _responseDto.Message = "Cupones obtenidos con exito";
            }
            catch (Exception ex)
            {
                _responseDto.IsSuccess = false;
                _responseDto.Message = "Ocurrio un error al obtener los cupones: "+ex.Message;
            }

            return _responseDto;
        }

        [HttpGet]
        [Route("{id:int}")]
        public ResponseDto GetById(int id)
        {
            try
            {
                Coupon coupon = _db.Coupons.FirstOrDefault(x => x.Id == id && !x.IsDeleted);
                if (coupon != null)
                {
                    var couponDto = _mapper.Map<CouponDto>(coupon);

                    _responseDto.Result = couponDto;
                    _responseDto.Message = $"Cupon {couponDto.CouponCode} recuperado con exito";
                }
            }
            catch (Exception ex)
            {
                _responseDto.IsSuccess = false;
                _responseDto.Message = "Ocurrio un error al obtener el coupon: " + ex.Message;
            }

            return _responseDto;
        }
    }
}
