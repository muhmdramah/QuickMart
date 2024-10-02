using AutoMapper;
using Core.Entities.OrderAggregate;
using Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QuickMart_Ecommerce_API.DTOs;
using QuickMart_Ecommerce_API.DTOs.Order;
using QuickMart_Ecommerce_API.Extensions;

namespace QuickMart_Ecommerce_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly IMapper _mapper;

        public OrdersController(IOrderService orderService, IMapper mapper)
        {
            _orderService = orderService;
            _mapper = mapper;
        }


        [HttpPost("CreateOrder")]
        public async Task<ActionResult<Order>> CreateOrder(OrderDto orderDto)
        {
            var email = HttpContext.User.RetrieveEmailFromPrincipal();

            var address = _mapper.Map<AddressDto, Address>(orderDto.ShippToAddress);

            var order = await _orderService.CreateOrderAsync(email, orderDto.DeliveryMethodId,
                orderDto.BasketId, address);

            if (order is null)
                return BadRequest("Error occurred while creating an order!");

            return Ok(order);
        }


        [HttpGet("GetAllOrders")]
        public async Task<ActionResult<IReadOnlyList<OrderToReturnDto>>> GetAllOrders()
        {
            var email = HttpContext.User.RetrieveEmailFromPrincipal();

            var orders = await _orderService.GetOrdersForUserAsync(email);

            return Ok(_mapper.Map<IReadOnlyList<OrderToReturnDto>>(orders));
        }

        [HttpGet("GetOrderById{id}")]
        public async Task<ActionResult<IReadOnlyList<OrderToReturnDto>>> GetOrderById(int id)
        {
            var email = HttpContext.User.RetrieveEmailFromPrincipal();

            var order = await _orderService.GetOrdersByIdAsync(id, email);

            if (order is null)
                return BadRequest();

            return Ok(_mapper.Map<OrderToReturnDto>(order));
        }

        [HttpGet("GetAllDeliveryMethods")]
        public async Task<ActionResult<IReadOnlyList<DeliveryMethod>>> GetAllDeliveryMethods()
        {
            var deliveryMethods = await _orderService.GetDeliveryMethodsAsync();

            if (deliveryMethods is null)
                return BadRequest();

            return Ok(deliveryMethods);
        }
    }
}
