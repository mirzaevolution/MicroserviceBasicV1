using FxStore.ProductAPI.DtoModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FxStore.ProductAPI.Services
{
    public interface IProductService
    {
        Task<List<ProductDto>> GetAll();
        Task<bool> CheckAvailability(string id);
        Task<bool> DecreaseProductCount(string id, int count);
    }
}
