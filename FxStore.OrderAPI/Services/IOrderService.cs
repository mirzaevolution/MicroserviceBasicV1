using FxStore.OrderAPI.DtoModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FxStore.OrderAPI.Services
{
    public interface IOrderService
    {
        Task<bool> PlaceOrder(OrderDto order);
        Task<bool> CheckProductAvailability(string id);
        Task<bool> DecreaseProductCount(string id, int count);
        Task InsertToOrderHistoryAPI(OrderDto order); 
    }
}
