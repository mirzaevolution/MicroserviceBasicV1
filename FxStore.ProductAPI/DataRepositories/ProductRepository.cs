using FxStore.ProductAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FxStore.ProductAPI.DataRepositories
{
    public class ProductRepository
    {
        private static List<Product> _allProducts = new List<Product>
        {
            new Product
            {
                Name = "Lenovo Legion",
                Description = "Lenovo Gaming Laptop",
                Price = 1500,
                StockCount = 100
            },
            new Product
            {
                Name = "Asus Rog",
                Description = "Asus Gaming Laptop",
                Price = 1200,
                StockCount = 30
            },
            new Product
            {
                Name = "Acer Predator",
                Description = "Acer Gaming Laptop",
                Price = 1300,
                StockCount = 60
            },
            new Product
            {
                Name = "Dell Alieneware R5",
                Description = "Ultimate Gaming Laptop",
                Price = 4500,
                StockCount = 4
            }
        };
        public List<Product> GetProducts() => _allProducts;
        public bool DecreaseProductCount(string id, int count)
        {
            Product product = _allProducts.FirstOrDefault(c => c.Id == id);
            if (product != null && product.StockCount >=count)
            {
                product.StockCount -= count;
                return true;
            }
            return false;
        }
        public int GetProductCount(string id)
        {
            Product product = _allProducts.FirstOrDefault(c => c.Id == id);
            if (product != null)
            {
                return product.StockCount;
            }
            return -1;
        }
        public void AddNewProduct(Product product)
        {
            _allProducts.Add(product);
        }
        public void UpdateProduct(Product product)
        {
            Product existingProduct = _allProducts.FirstOrDefault(c => c.Id == product.Id);
            if (existingProduct != null)
            {
                existingProduct.Name = product.Name;
                existingProduct.Description = product.Description;
                existingProduct.StockCount = product.StockCount;
            }
        }
    }
}
