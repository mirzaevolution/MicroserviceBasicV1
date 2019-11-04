using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FxStore.ProductAPI.Filters;
using FxStore.ProductAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FxStore.ProductAPI.Controllers.Api
{
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        #region Public APIs

        [Authorize]
        [HttpGet("Api/Products/GetAll")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _productService.GetAll());
        }

        #endregion

        #region Private APIs
        [PrivateEndpoint]
        [HttpGet("Api/Products/CheckProductAvailability/{id}")]
        public async Task<IActionResult> CheckProductAvailability(string id)
        {
            return Ok(new
            {
                IsAvailable = await _productService.CheckAvailability(id)
            });
        }
        [PrivateEndpoint]
        [HttpPost("Api/Products/DecreaseProductCount/{id}")]
        public async Task<IActionResult> DecreaseProductCount(string id, [FromBody]int count)
        {
            var result = await _productService.DecreaseProductCount(id, count);
            return Ok(new
            {
                Success = result ? true : false
            });
        }
        #endregion



    }
}