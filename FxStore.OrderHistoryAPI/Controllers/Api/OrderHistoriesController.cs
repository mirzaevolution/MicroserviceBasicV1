using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using FxStore.OrderHistoryAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FxStore.OrderHistoryAPI.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class OrderHistoriesController : ControllerBase
    {
        private IOrderHistoryService _service;
        public OrderHistoriesController(IOrderHistoryService orderHistory)
        {
            _service = orderHistory;
        }
        public async Task<IActionResult> GetAll()
        {
            string userId = User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier).Value;
            var result = await _service.GetAllHistories(userId);
            return Ok(result);
        }
    }
}