using AutoMapper;
using Microservices.BackEnd.ProductAPI.Data;
using Microservices.BackEnd.ProductAPI.Models;
using Microservices.BackEnd.ProductAPI.Models.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Microservices.BackEnd.CouponAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProductsAPIController : ControllerBase
    {
        private readonly ApplicationDbContext _db;
        private ResponseDto _responseDto;
        private readonly IMapper _mapper;
        public ProductsAPIController(ApplicationDbContext db, IMapper mapper)
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
                List<ProductDto> productDtoList = new();
                var newProductDto = new ProductDto();
                IEnumerable<Product> productList = _db.Products.Where(x=>!x.IsDeleted).ToList();
                //_responseDto.Result = _mapper.Map<IEnumerable<CouponDto>>(couponList);
                if(productList.Count() > 0)
                {
                    foreach(var product in productList)
                    {
                        newProductDto.Id = product.Id;
                        newProductDto.Name = product.Name;
                        newProductDto.Price = product.Price;
                        newProductDto.Description = product.Description;
                        newProductDto.CategoryName = product.CategoryName;
                        newProductDto.ImageUrl = product.ImageUrl;

                        productDtoList.Add(newProductDto);
                        newProductDto = new ProductDto();
                    }
                }

                _responseDto.Result = productDtoList;
                _responseDto.Message = "Productos obtenidos con exito";
            }
            catch (Exception ex)
            {
                _responseDto.IsSuccess = false;
                _responseDto.Message = "Ocurrio un error al obtener los productos: "+ex.Message;
            }

            return _responseDto;
        }

        [HttpGet]
        [Route("{id:int}")]
        public ResponseDto GetById(int id)
        {
            try
            {
                var newProductDto = new ProductDto();
                Product? product = _db.Products.FirstOrDefault(x => x.Id == id && !x.IsDeleted);
                if (product != null)
                {
                    //var couponDto = _mapper.Map<CouponDto>(coupon);

                    newProductDto.Id = product.Id;
                    newProductDto.Name = product.Name;
                    newProductDto.Price = product.Price;
                    newProductDto.Description = product.Description;
                    newProductDto.CategoryName = product.CategoryName;
                    newProductDto.ImageUrl = product.ImageUrl;

                    _responseDto.Result = newProductDto;
                    _responseDto.Message = $"Producto {newProductDto.Name} recuperado con exito";
                }
            }
            catch (Exception ex)
            {
                _responseDto.IsSuccess = false;
                _responseDto.Message = "Ocurrio un error al obtener el producto: " + ex.Message;
            }

            return _responseDto;
        }


        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ResponseDto Post([FromBody] ProductDto productDto)
        {
            try
            {
                var newProduct = new Product();
                if(productDto != null)
                {
                    newProduct.Name = productDto.Name;
                    newProduct.Price = productDto.Price;
                    newProduct.Description = productDto.Description;
                    newProduct.CategoryName = productDto.CategoryName;
                    newProduct.ImageUrl = productDto.ImageUrl;
                    newProduct.IsDeleted = false;

                    _db.Products.Add(newProduct);
                    _db.SaveChanges();

                    _responseDto.Result = newProduct.Id;
                    _responseDto.Message = $"Producto {productDto.Name} creado con exito";
                }
                else
                {
                    _responseDto.Result = null;
                    _responseDto.IsSuccess=false;
                    _responseDto.Message = $"El producto ingresado no es valido";
                }
            }
            catch (Exception ex)
            {
                _responseDto.IsSuccess = false;
                _responseDto.Message = "Ocurrio un error al crear el producto: " + ex.Message;
            }

            return _responseDto;
        }

        [HttpPut]
        public ResponseDto Put([FromBody] ProductDto productDto)
        {
            try
            {
                var newProduct = new Product();
                Product? product = _db.Products.FirstOrDefault(x => x.Id == productDto.Id && !x.IsDeleted);
                if (product != null)
                {
                    product.Name = productDto.Name;
                    product.Price = productDto.Price;
                    product.Description = productDto.Description;
                    product.CategoryName = productDto.CategoryName;
                    product.ImageUrl = productDto.ImageUrl;

                    _db.Products.Update(product);
                    _db.SaveChanges();

                    _responseDto.Result = productDto.Id;
                    _responseDto.Message = $"Producto {product.Name} actualizado con exito";
                }
                else
                {
                    _responseDto.Result = null;
                    _responseDto.IsSuccess = false;
                    _responseDto.Message = $"No se encontro el producto ingresado";
                }
            }
            catch (Exception ex)
            {
                _responseDto.IsSuccess = false;
                _responseDto.Message = "Ocurrio un error al actualizar el producto: " + ex.Message;
            }

            return _responseDto;
        }

        [HttpDelete]
        [Route("{id:int}")]
        public ResponseDto Delete(int id)
        {
            try
            {
                Product? product = _db.Products.FirstOrDefault(x => x.Id == id && !x.IsDeleted);
                if (product != null)
                {
                    product.IsDeleted = true;

                    _db.Products.Update(product);
                    _db.SaveChanges();

                    _responseDto.Result = true;
                    _responseDto.Message = $"Producto {product.Name} eliminado con exito";
                }
                else
                {
                    _responseDto.Result = null;
                    _responseDto.IsSuccess = false;
                    _responseDto.Message = $"No se encontro el producto ingresado";
                }
            }
            catch (Exception ex)
            {
                _responseDto.IsSuccess = false;
                _responseDto.Message = "Ocurrio un error al eliminar el producto: " + ex.Message;
            }

            return _responseDto;
        }
    }
}
