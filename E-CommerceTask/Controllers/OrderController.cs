using Core.Repositories.Interfaces;
using Infrastructure.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace E_CommerceTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepository _orderRepository;
        public OrderController(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        [HttpPost]
        public async Task CreateOrder(OrderDTO order) 
        {
            await _orderRepository.CreateAsync(order);
        }
    }
}
