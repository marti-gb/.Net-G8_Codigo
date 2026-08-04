using Microservices.FrontEnd.Web.Models;
using Microservices.FrontEnd.Web.Models.ProductDto;
using Microservices.FrontEnd.Web.Service.IService;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Microservices.FrontEnd.Web.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductService _productService;
        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> ProductIndex()
        {
            List<ProductDto>? listProducts = new();
            ResponseDto? responseDto = await _productService.GetAllProductAsync();
            if (responseDto != null && responseDto.IsSuccess)
            {
                listProducts = JsonConvert.DeserializeObject<List<ProductDto>>(Convert.ToString(responseDto.Result)!);
            }
            else
            {
                TempData["error"] = responseDto.Message;
            }
            return View(listProducts);
        }

        #region Post
        [HttpGet]
        public async Task<IActionResult> ProductCreate()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ProductCreate(ProductDto productDto)
        {
            if (ModelState.IsValid)
            {
                ResponseDto? responseDto = await _productService.CreateProductAsync(productDto);

                if (responseDto != null && responseDto.IsSuccess)
                {
                    TempData["success"] = "Producto creado existosamente";
                    return RedirectToAction(nameof(ProductIndex));
                }
                else
                {
                    TempData["error"] = responseDto.Message;
                }
            }
            return View(productDto);
        }
        #endregion

        #region Edit
        [HttpGet]
        public async Task<IActionResult> ProductEdit(int productId)
        {
            ProductDto? productDto = new();
            ResponseDto? responseDto = await _productService.GetProductByIdAsync(productId);
            if (responseDto != null && responseDto.IsSuccess)
            {
                productDto = JsonConvert.DeserializeObject<ProductDto>(Convert.ToString(responseDto.Result)!);
                return View(productDto);
            }
            else
            {
                TempData["error"] = responseDto.Message;
                return View();
            }
        }

        [HttpPost]
        public async Task<IActionResult> ProductEdit(ProductDto productDto)
        {
            if (ModelState.IsValid)
            {
                ResponseDto? responseDto = await _productService.UpdateProductAsync(productDto);

                if (responseDto != null && responseDto.IsSuccess)
                {
                    TempData["success"] = "Producto editado existosamente";
                    return RedirectToAction(nameof(ProductIndex));
                }
                else
                {
                    TempData["error"] = responseDto.Message;
                    return View(productDto);
                }
            }
            return View(productDto);

        }
        #endregion

        #region Delete
        [HttpGet]
        public async Task<IActionResult> ProductDelete(int productId)
        {
            ProductDto? productDto = new();
            ResponseDto? responseDto = await _productService.GetProductByIdAsync(productId);
            if (responseDto != null && responseDto.IsSuccess)
            {
                productDto = JsonConvert.DeserializeObject<ProductDto>(Convert.ToString(responseDto.Result)!);
                return View(productDto);
            }
            else
            {
                TempData["error"] = responseDto.Message;
                return View();
            }
        }

        [HttpPost]
        public async Task<IActionResult> ProductDelete(ProductDto productDto)
        {

            ResponseDto? responseDto = await _productService.DeleteProductAsync(productDto.Id);

            if (responseDto != null && responseDto.IsSuccess)
            {
                TempData["success"] = "Producto eliminado existosamente";
                return RedirectToAction(nameof(ProductIndex));
            }
            else
            {
                TempData["error"] = responseDto.Message;
                return View(productDto);
            }
        }
        #endregion

    }
}
