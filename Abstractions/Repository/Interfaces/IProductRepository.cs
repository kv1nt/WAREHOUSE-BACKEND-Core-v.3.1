﻿using Entities.Models;
using Entities.Models.DTO;
using Microsoft.Extensions.Configuration;
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
        IEnumerable<Product> GetByName(string productName);
        IEnumerable<ProductDTO> SearchByParameters(ProductDTO product, IConfiguration _Configuration);
        Product FindByCondition(Guid id);
        bool CreateProduct(ProductDTO product);
        void UpdateProduct(ProductDTO product);
        void DeleteProduct(ProductDTO product);
    }
}
