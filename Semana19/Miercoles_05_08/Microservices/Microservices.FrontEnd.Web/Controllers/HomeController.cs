using Microservices.FrontEnd.Web.Models;
using Microservices.FrontEnd.Web.Models.ProductDtos;
using Microservices.FrontEnd.Web.Models.ShoppingCartDto;
using Microservices.FrontEnd.Web.Service.IService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;

namespace Microservices.FrontEnd.Web.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductService _productService;
        private readonly IShoppingCartService _shoppingCartService;

        public HomeController(ILogger<HomeController> logger, IProductService productService,
            IShoppingCartService shoppingCartService)
        {
            _logger = logger;
            _productService = productService;
            _shoppingCartService = shoppingCartService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<ProductDto>? listProducts = new();
            ResponseDto? responseDto = await _productService.GetAllProductAsync();

            if (responseDto != null && responseDto.IsSuccess)
            {
                listProducts = JsonConvert.DeserializeObject<List<ProductDto>>(Convert.ToString(responseDto.Result)!);
            }
            else
            {
                TempData["error"] = responseDto?.Message;
            }

            return View(listProducts);
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> ProductDetails(int productId)
        {
            ProductDto? productDto = new();

            ResponseDto? responseDto = await _productService.GetProductByIdAsync(productId);

            if (responseDto != null && responseDto.IsSuccess)
            {
                productDto = JsonConvert.DeserializeObject<ProductDto>(Convert.ToString(responseDto.Result)!);
            }
            else
            {
                TempData["error"] = responseDto?.Message;
            }

            return View(productDto);
        }

        [HttpPost]
        public async Task<IActionResult> ProductDetails(ProductDto productDto)
        {
            CartDto cartDto = new CartDto()
            {
                CartHeaderDto = new CartHeaderDto()
                {
                    UserId = User.Claims.Where(x => x.Type == JwtRegisteredClaimNames.Sub).FirstOrDefault().Value
                }
            };

            CartDetailsDto cartDetailsDto = new CartDetailsDto()
            {
                Count = productDto.Count,
                ProductId = productDto.Id
            };

            List<CartDetailsDto> cartDetailsDtos = new() { cartDetailsDto };
            cartDto.CartDetailsDtos = cartDetailsDtos;

            ResponseDto? responseDto = await _shoppingCartService.UpSertCartAsync(cartDto);
            if (responseDto != null && responseDto.IsSuccess)
            {
                TempData["success"] = "Item agregado exitosamente al shopping cart";
                return RedirectToAction(nameof(Index));
            }
            else
            {
                TempData["error"] = responseDto?.Message;
            }

            return View(productDto);
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
