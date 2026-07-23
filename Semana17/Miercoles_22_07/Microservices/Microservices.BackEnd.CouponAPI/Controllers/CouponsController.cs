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
                List<CouponDto> couponDtoList = new();
                var newCouponDto = new CouponDto();
                IEnumerable<Coupon> couponList = _db.Coupons.Where(x=>!x.IsDeleted).ToList();
                //_responseDto.Result = _mapper.Map<IEnumerable<CouponDto>>(couponList);
                if(couponList.Count() > 0)
                {
                    foreach(var coupon in couponList)
                    {
                        newCouponDto.Id = coupon.Id;
                        newCouponDto.CouponCode = coupon.CouponCode;
                        newCouponDto.DiscountAmount = coupon.DiscountAmount;
                        newCouponDto.MinimunAmount = coupon.MinimunAmount;

                        couponDtoList.Add(newCouponDto);
                        newCouponDto = new CouponDto();
                    }
                }

                _responseDto.Result = couponDtoList;
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
                var newCouponDto = new CouponDto();
                Coupon coupon = _db.Coupons.FirstOrDefault(x => x.Id == id && !x.IsDeleted);
                if (coupon != null)
                {
                    //var couponDto = _mapper.Map<CouponDto>(coupon);

                    newCouponDto.Id = coupon.Id;
                    newCouponDto.CouponCode = coupon.CouponCode;
                    newCouponDto.DiscountAmount = coupon.DiscountAmount;
                    newCouponDto.MinimunAmount = coupon.MinimunAmount;

                    _responseDto.Result = newCouponDto;
                    _responseDto.Message = $"Cupon {newCouponDto.CouponCode} recuperado con exito";
                }
            }
            catch (Exception ex)
            {
                _responseDto.IsSuccess = false;
                _responseDto.Message = "Ocurrio un error al obtener el coupon: " + ex.Message;
            }

            return _responseDto;
        }

        [HttpGet]
        [Route("GetByCode/{code}")]
        public ResponseDto GetByCode(string code)
        {
            try
            {
                var newCouponDto = new CouponDto();
                Coupon coupon = _db.Coupons.FirstOrDefault(x => x.CouponCode == code && !x.IsDeleted);
                if (coupon != null)
                {
                    //var couponDto = _mapper.Map<CouponDto>(coupon);
                    newCouponDto.Id = coupon.Id;
                    newCouponDto.CouponCode = coupon.CouponCode;
                    newCouponDto.DiscountAmount = coupon.DiscountAmount;
                    newCouponDto.MinimunAmount = coupon.MinimunAmount;

                    _responseDto.Result = newCouponDto;
                    _responseDto.Message = $"Cupon {newCouponDto.CouponCode} recuperado con exito";
                }
            }
            catch (Exception ex)
            {
                _responseDto.IsSuccess = false;
                _responseDto.Message = "Ocurrio un error al obtener el coupon: " + ex.Message;
            }

            return _responseDto;
        }

        [HttpPost]
        public ResponseDto Post([FromBody] CouponDto couponDto)
        {
            try
            {
                var newCoupon = new Coupon();
                if(couponDto != null)
                {
                    newCoupon.CouponCode = couponDto.CouponCode;
                    newCoupon.DiscountAmount = couponDto.DiscountAmount;
                    newCoupon.MinimunAmount = couponDto.MinimunAmount;
                    newCoupon.IsDeleted = false;

                    _db.Coupons.Add(newCoupon);
                    _db.SaveChanges();

                    _responseDto.Result = newCoupon.Id;
                    _responseDto.Message = $"Cupon {couponDto.CouponCode} creado con exito";
                }
                else
                {
                    _responseDto.Result = null;
                    _responseDto.IsSuccess=false;
                    _responseDto.Message = $"El cupon ingresado no es valido";
                }
            }
            catch (Exception ex)
            {
                _responseDto.IsSuccess = false;
                _responseDto.Message = "Ocurrio un error al crear el coupon: " + ex.Message;
            }

            return _responseDto;
        }

        [HttpPut]
        public ResponseDto Put([FromBody] CouponDto couponDto)
        {
            try
            {
                var newCoupon = new Coupon();
                Coupon coupon = _db.Coupons.FirstOrDefault(x => x.Id == couponDto.Id && !x.IsDeleted);
                if (coupon != null)
                {
                    coupon.CouponCode = couponDto.CouponCode;
                    coupon.DiscountAmount = couponDto.DiscountAmount;
                    coupon.MinimunAmount = couponDto.MinimunAmount;

                    _db.Coupons.Update(coupon);
                    _db.SaveChanges();

                    _responseDto.Result = couponDto.Id;
                    _responseDto.Message = $"Cupon {coupon.CouponCode} actualizado con exito";
                }
                else
                {
                    _responseDto.Result = null;
                    _responseDto.IsSuccess = false;
                    _responseDto.Message = $"No se encontro el cupon ingresado";
                }
            }
            catch (Exception ex)
            {
                _responseDto.IsSuccess = false;
                _responseDto.Message = "Ocurrio un error al actualizar el coupon: " + ex.Message;
            }

            return _responseDto;
        }

        [HttpDelete]
        [Route("{id:int}")]
        public ResponseDto Delete(int id)
        {
            try
            {
                Coupon coupon = _db.Coupons.FirstOrDefault(x => x.Id == id && !x.IsDeleted);
                if (coupon != null)
                {
                    coupon.IsDeleted = true;

                    _db.Coupons.Update(coupon);
                    _db.SaveChanges();

                    _responseDto.Result = true;
                    _responseDto.Message = $"Cupon {coupon.CouponCode} eliminado con exito";
                }
                else
                {
                    _responseDto.Result = null;
                    _responseDto.IsSuccess = false;
                    _responseDto.Message = $"No se encontro el cupon ingresado";
                }
            }
            catch (Exception ex)
            {
                _responseDto.IsSuccess = false;
                _responseDto.Message = "Ocurrio un error al eliminar el coupon: " + ex.Message;
            }

            return _responseDto;
        }
    }
}
