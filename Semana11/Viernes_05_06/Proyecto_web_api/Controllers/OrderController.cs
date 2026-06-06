using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Proyecto_web_api.Models.Dto;
using Proyecto_web_api.Repository;

namespace Proyecto_web_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly RepositoryOneToOneMany _repositoryOneToOneMany;
        public OrderController(RepositoryOneToOneMany repositoryOneToOneMany)
        {
            _repositoryOneToOneMany = repositoryOneToOneMany;
        }

        [HttpGet("orders")]
        public async Task<IActionResult> GetOrders()
        {
            var orders = await _repositoryOneToOneMany.GetOrders();
            return Ok(orders);
        }

        [HttpGet("orderById")]
        public async Task<IActionResult> GetOrder(int id)
        {
            var order = await _repositoryOneToOneMany.GetOrderById(id);
            return Ok(order);
        }

        [HttpPost]
        public async Task<IActionResult> AddOrder(OrderDto orderDto)
        {
            var newOrder = await _repositoryOneToOneMany.AddOrder(orderDto);
            return Ok(newOrder);
        }

        [HttpPut]
        public async Task<IActionResult> EditOrder(int id, OrderDto orderDto)
        {
            var orderUpdate = await _repositoryOneToOneMany.EditOrder(id, orderDto);
            return Ok(orderUpdate);
        }
    }
}
