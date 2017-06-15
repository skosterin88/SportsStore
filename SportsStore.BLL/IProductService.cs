using System;
using System.Collections.Generic;

namespace SportsStore.BLL
{
    public interface IProductService : IDisposable
    {
        void AddProduct(ProductDto productDto);
        ProductDto GetProduct(int id);
        IEnumerable<ProductDto> GetAllProducts();
    }
}