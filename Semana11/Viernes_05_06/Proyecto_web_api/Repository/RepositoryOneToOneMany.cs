using Microsoft.EntityFrameworkCore;
using Proyecto_web_api.Data;
using Proyecto_web_api.Models.Dto;
using Proyecto_web_api.Models.OneToMany;

namespace Proyecto_web_api.Repository
{
    public class RepositoryOneToOneMany
    {
        private readonly AppDbContext _context;
        public RepositoryOneToOneMany(AppDbContext context)
        {
            _context = context;
        }
        public async Task<List<OrderDto>> GetOrders()
        {
            var orders = await _context.Orders
                                .Include(x => x.OrderDetails)
                                .ToListAsync();

            var oderDto = orders.Select(s=> new OrderDto
            {
                Id = s.Id,
                CustomerName = s.CustomerName,
                OrderDate = s.OrderDate,
                OrderDetailsDto = s.OrderDetails?.Select(l=> new OrderDetailDto
                {
                    Id= l.Id,
                    Quantity = l.Quantity,
                    Price = l.Price,
                }).ToList()
            }).ToList();

            return oderDto;
        }

        public async Task<OrderDto> GetOrderById(int id)
        {
            var order = await _context.Orders
                                .Include(x=>x.OrderDetails)
                                .FirstOrDefaultAsync(d=>d.Id == id);

            if(order == null) return new OrderDto();

            var orderDto = new OrderDto
            {
                Id = order.Id,
                CustomerName = order.CustomerName,
                OrderDate = order.OrderDate,
                OrderDetailsDto = order?.OrderDetails?.Select(c => new OrderDetailDto
                {
                    Id = c.Id,
                    Quantity = c.Quantity,
                    Price = c.Price,
                }).ToList()
            };

            return orderDto;
        }

        public async Task<OrderDto> AddOrder(OrderDto orderDto)
        {
            var newOrder = new Order();
            var newOrderDto = new OrderDto();

            if (orderDto == null || orderDto?.OrderDetailsDto?.Count == 0)
            {
                return newOrderDto;
            }
            else
            {
                newOrder = new Order()
                {
                    CustomerName = orderDto.CustomerName,
                    OrderDate = orderDto.OrderDate,
                    OrderDetails = orderDto?.OrderDetailsDto?.Select(x => new OrderDetail
                    {
                        Quantity = x.Quantity,
                        Price = x.Price,
                    }).ToList()
                }
                ;

                await _context.Orders.AddAsync(newOrder);
                await _context.SaveChangesAsync();
            }

            newOrderDto = new OrderDto
            {
                Id = newOrder.Id,
                CustomerName = newOrder.CustomerName,
                OrderDate = newOrder.OrderDate,
                OrderDetailsDto = newOrder.OrderDetails.Select(x => new OrderDetailDto
                {
                    Id = x.Id,
                    Quantity = x.Quantity,
                    Price = x.Price,
                }).ToList()
            };

            return newOrderDto;
        }


        public async Task<OrderDto> EditOrder(OrderDto orderDto)
        {
            var newOrder = new Order();
            var newOrderDto = new OrderDto();

            if (orderDto.Id <= 0)
            {
                return newOrderDto;
            }
            else
            {
                var order = await _context.Orders
                    .Include(x=>x.OrderDetails)
                    .FirstOrDefaultAsync(p=>p.Id == orderDto.Id);

                if (order == null) { return newOrderDto; }

                order.CustomerName = orderDto.CustomerName;
                order.OrderDate = orderDto.OrderDate;

                //Eliminamos todos los detalles existentes para luego agregarlos
                _context.OrderDetails.RemoveRange(order?.OrderDetails);
                order.OrderDetails = orderDto?.OrderDetailsDto?.Select(x=> new OrderDetail
                {
                    Id = x.Id,
                    Quantity= x.Quantity,
                    Price = x.Price,
                }).ToList();

                try
                {
                    await _context.SaveChangesAsync();
                    return orderDto;
                }
                catch (Exception ex)
                {
                    return new OrderDto();
                }
            }
        }
    }
}
