using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using FxStore.OrderAPI.DtoModels;
using FxStore.OrderAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FxStore.OrderAPI.Controllers.Api
{
    [ApiController]
    [Authorize]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;
        
        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }
        [HttpPost("Api/Orders/PlaceOrder")]
        public async Task<IActionResult> PlaceOrder(OrderDto orderDto)
        {
            if (orderDto == null)
                return BadRequest(new
                {
                    error = "Empty payload is not allowed"
                });
            orderDto.UserId = User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier).Value;
            var result = await _orderService.PlaceOrder(orderDto);
            if (result)
            {
                return Ok("Order successfully");
            }
            return BadRequest(new { error = "Order failure" });
        }
    }
}