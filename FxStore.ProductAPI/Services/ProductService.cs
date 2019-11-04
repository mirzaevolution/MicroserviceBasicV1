using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FxStore.ProductAPI.DataRepositories;
using FxStore.ProductAPI.DtoModels;
using FxStore.ProductAPI.Models;

namespace FxStore.ProductAPI.Services
{
    public class ProductService : IProductService
    {
        private ProductRepository _repository = new ProductRepository();
        private readonly IMapper _mapper;
        public ProductService(IMapper mapper)
        {
            _mapper = mapper;
        }
        public Task<bool> CheckAvailability(string id)
        {
            return Task.FromResult(_repository.GetProductCount(id) >= 0 ? true : false);
        }

        public Task<List<ProductDto>> GetAll()
        {
            var result = _mapper.Map<List<Product>, List<ProductDto>>(_repository.GetProducts());
            return Task.FromResult(result);
        }

        public Task<bool> DecreaseProductCount(string id, int count)
        {
            return Task.FromResult(_repository.DecreaseProductCount(id, count));
        }
    }
}
