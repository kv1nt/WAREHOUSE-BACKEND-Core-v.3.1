using Abstractions.Repository;
using Abstractions.Repository.Interfaces;
using DBSearchLib;
using Entities;
using Entities.Models;
using Entities.Models.DTO;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public bool CreateProduct(ProductDTO product)
        {
            if (product != null)
            {
                try
                {
                    Create(new Product()
                    {
                        Id = Guid.NewGuid(),
                        Weight = product.Weight,
                        Color = product.Color,
                        Price = product.Price,
                        Type = product.Type,
                        Name = product.Name,
                        Description = product.Description,
                    });
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return true;
            }
            else
            {
                return false;
            }
        }

        public IEnumerable<Product> FindAllProducts()
        {
            return FindAll();
        }

        public void DeleteProduct(ProductDTO product)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Product> FindAllProducts(string userId)
        {
            throw new NotImplementedException();
        }


        public Product FindByCondition(Guid id)
        {
            return RepositoryContext.Products
                    .Where(p => p.Id == id).FirstOrDefault();
        }


        public IEnumerable<Product> GetByName(string name)
        {
           return  RepositoryContext.
                               Products?.Where(p =>
                               p.Name == name);
        }



        public IEnumerable<Product> FindByCondition(ProductDTO product)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ProductDTO> SearchByParameters(ProductDTO product, IConfiguration _Configuration)
        {
            if (product.Price == 0) product.Price = null;
            if (product.Weight == 0) product.Weight = null;

            using (var serachService = new SerachService())
            {
                string conString = ConfigurationExtensions.GetConnectionString(_Configuration, "mssqlconnection");
                var products = serachService.Search(product, "Product", conString);
                return products;
            }
        }

        public IQueryable<ProductDTO> FindByCondition(Expression<Func<ProductDTO, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public void UpdateProduct(ProductDTO product)
        {
            throw new NotImplementedException();
        }
    }
}
