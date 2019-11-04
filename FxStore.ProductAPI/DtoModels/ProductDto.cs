using System;

namespace FxStore.ProductAPI.DtoModels
{
    public class ProductDto
    {

        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int StockCount { get; set; }
    }
}
