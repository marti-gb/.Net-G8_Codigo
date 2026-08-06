using Microservices.FrontEnd.Web.Models;
using Microservices.FrontEnd.Web.Models.ShoppingCartDto;
using Microservices.FrontEnd.Web.Service.IService;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;

namespace Microservices.FrontEnd.Web.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly IShoppingCartService _shoppingCartService;

        public ShoppingCartController(IShoppingCartService shoppingCartService)
        {
            _shoppingCartService = shoppingCartService;
        }


        public async Task<IActionResult> ShoppingCartIndex()
        {
            return View(await LoadCartDtoBassedOnLoggedInUser());
        }

        private async Task<CartDto> LoadCartDtoBassedOnLoggedInUser()
        {
            var userId = User.Claims.Where(x=>x.Type == JwtRegisteredClaimNames.Sub)?.FirstOrDefault()?.Value;
            ResponseDto? responseDto = await _shoppingCartService.GetCartByUserIdAsync(userId!); 
            if(responseDto != null && responseDto.IsSuccess)
            {
                CartDto cartDto = JsonConvert.DeserializeObject<CartDto>(Convert.ToString(responseDto.Result)!)!;
                return cartDto;
            }
            return new CartDto();
        }
    }
}
