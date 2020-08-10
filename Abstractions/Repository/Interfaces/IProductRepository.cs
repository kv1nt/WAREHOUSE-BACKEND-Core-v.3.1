using Entities.Models;
using Entities.Models.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Abstractions.Repository.Interfaces
{
    public interface IProductRepository : IRepository<Product>
    {
        IEnumerable<Product> FindAllProducts(string userId);
        IEnumerable<Product> FindAllProducts();
        Product FindByCondition(Guid id);
        bool CreateProduct(ProductDTO product);
        void UpdateProduct(ProductDTO product);
        void DeleteProduct(ProductDTO product);
    }
}
