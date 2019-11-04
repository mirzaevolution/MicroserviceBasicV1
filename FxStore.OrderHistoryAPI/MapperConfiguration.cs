using AutoMapper;
using FxStore.OrderHistoryAPI.DtoModels;
using FxStore.OrderHistoryAPI.Models;

namespace FxStore.OrderHistoryAPI
{
    public class MapperConfiguration:Profile
    {
        public MapperConfiguration()
        {
            CreateMap<OrderHistory, OrderHistoryDto>().ReverseMap();
        }
    }
}
