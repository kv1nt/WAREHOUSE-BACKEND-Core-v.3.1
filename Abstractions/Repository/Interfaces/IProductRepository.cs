using Entities.Models;
using Entities.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstractions.Repository.Interfaces
{
    public interface IProductRepository : IRepository<Product>
    {
        IEnumerable<Product> FindAllProducts(string userId);
        IEnumerable<Product> FindAllProducts();
        IEnumerable<Product> FindByCondition(ProductDTO product);
        Task<IQueryable<Product>> GetByNameAsync(ProductDTO product);
        Task<IQueryable<Product>> GetByWeightAsync(ProductDTO product);
        Task<IQueryable<Product>> GetByPriceAsync(ProductDTO product);
        Product FindByCondition(Guid id);
        bool CreateProduct(ProductDTO product);
        void UpdateProduct(ProductDTO product);
        void DeleteProduct(ProductDTO product);
    }
}
