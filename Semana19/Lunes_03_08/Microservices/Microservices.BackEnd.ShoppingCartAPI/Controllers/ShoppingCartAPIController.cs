using AutoMapper;
using Microservices.BackEnd.ShoppingCartAPI.Data;
using Microservices.BackEnd.ShoppingCartAPI.Models;
using Microservices.BackEnd.ShoppingCartAPI.Models.Dto;
using Microservices.BackEnd.ShoppingCartAPI.Service.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Microservices.BackEnd.ShoppingCartAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingCartAPIController : ControllerBase
    {
        private readonly ApplicationDbContext _db;
        private ResponseDto _responseDto;
        private readonly IMapper _mapper;
        private readonly ICouponService _couponService;
        private readonly IProductService _productService;
        private readonly IConfiguration _configuration;

        public ShoppingCartAPIController(ApplicationDbContext db,
            IMapper mapper,
            ICouponService couponService,
            IProductService productService,
            IConfiguration configuration)
        {
            _db = db;
            _mapper = mapper;
            _couponService = couponService;
            _productService = productService;
            _configuration = configuration;
            _responseDto = new ResponseDto();
        }

        [HttpPost("ApplyCoupon")]
        public ResponseDto? ApplyCoupon([FromBody] CartDto cartDto)
        {
            try
            {
                CartHeader? cartHeaderFromDb = _db.CartHeaders
                    .FirstOrDefault(x => x.UserId == cartDto.CartHeaderDto.UserId && !x.IsDeleted);

                if (cartHeaderFromDb != null)
                {
                    cartHeaderFromDb.CouponCode = cartDto?.CartHeaderDto.CouponCode;

                    _db.CartHeaders.Update(cartHeaderFromDb);
                    _db.SaveChanges();
                }

                _responseDto.Result = true;
                _responseDto.Message = "Cupon aplicado exitosamente";
            }
            catch (Exception ex)
            {
                _responseDto.IsSuccess = false;
                _responseDto.Message = "Ocurrio un error: " + ex.Message;
            }

            return _responseDto;
        }

        [HttpPost("RemoveCoupon")]
        public ResponseDto RemoveCoupon([FromBody] ApplyCouponDto applyCouponDto)
        {
            try
            {
                CartHeader? cartHeaderFromDb = _db.CartHeaders
                    .FirstOrDefault(x => x.UserId == applyCouponDto.UserId && !x.IsDeleted);

                if(cartHeaderFromDb != null)
                {
                    cartHeaderFromDb.CouponCode = "";

                    _db.CartHeaders .Update(cartHeaderFromDb);
                    _db.SaveChanges();
                }

                _responseDto.Result = true;
                _responseDto.Message = "Cupon eliminado exitosamente";
            }
            catch (Exception ex)
            {
                _responseDto.IsSuccess = false;
                _responseDto.Message = "Ocurrio un error: " + ex.Message;
            }

            return _responseDto;
        }

    }
}
