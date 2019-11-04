using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FxStore.OrderHistoryAPI.DataRepositories;
using FxStore.OrderHistoryAPI.DtoModels;
using FxStore.OrderHistoryAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FxStore.OrderHistoryAPI.Services
{
    public class OrderHistoryService : IOrderHistoryService
    {
        private readonly OrderHistoryDbContext _context;
        private readonly IMapper _mapper;
        public OrderHistoryService(OrderHistoryDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<OrderHistoryDto>> GetAllHistories(string userId)
        {
            var result = _mapper.Map<List<OrderHistory>, List<OrderHistoryDto>>(await _context.OrderHistories.Where(c => c.UserId == userId).ToListAsync());
            return result;
        }
    }
}
