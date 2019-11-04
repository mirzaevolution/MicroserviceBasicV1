using FxStore.OrderHistoryAPI.DtoModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FxStore.OrderHistoryAPI.Services
{
    public interface IOrderHistoryService
    {
        Task<List<OrderHistoryDto>> GetAllHistories(string userId);
    }
}
