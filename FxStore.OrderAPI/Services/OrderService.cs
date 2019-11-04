using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using FxStore.OrderAPI.DtoModels;
using RabbitMQ.Client;
using Newtonsoft.Json;

namespace FxStore.OrderAPI.Services
{
    public class OrderService : IOrderService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly string _productEndpoint = "https://localhost:44369/Api/Products";
        public OrderService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<bool> PlaceOrder(OrderDto order)
        {
            if (await CheckProductAvailability(order.ProductId))
            {
                await InsertToOrderHistoryAPI(order);
                return await DecreaseProductCount(order.ProductId, order.Quantity);
            }
            return false;
        }
        public async Task<bool> CheckProductAvailability(string id)
        {
            var httpClient = _httpClientFactory.CreateClient();
            httpClient.DefaultRequestHeaders.Add("cross_token", "2812fx");
            var response = await httpClient.GetAsync($"{_productEndpoint}/CheckProductAvailability/{id}");
            if(response.IsSuccessStatusCode)
            {
                ProductAvailabilityDto productAvailabilityDto
                    = await response.Content.ReadAsAsync<ProductAvailabilityDto>();
                return productAvailabilityDto.IsAvailable;
            }
            return false;
        }
        public async Task<bool> DecreaseProductCount(string id,int count)
        {

            var httpClient = _httpClientFactory.CreateClient();
            httpClient.DefaultRequestHeaders.Add("cross_token", "2812fx");
            var response = await httpClient.PostAsJsonAsync<int>
                ($"{_productEndpoint}/DecreaseProductCount/{id}", count);
            if (response.IsSuccessStatusCode)
            {
                DecreaseProductCountResponseDto result
                    = await response.Content.ReadAsAsync<DecreaseProductCountResponseDto>();
                return result.Success;
            }
            return false;
        }

        public Task InsertToOrderHistoryAPI(OrderDto order)
        {
            string payload = JsonConvert.SerializeObject(order);
            RabbitMQCoreConnection.Send(payload, "OrderHistoryRepo");
            return Task.CompletedTask;
        }
    }
}
