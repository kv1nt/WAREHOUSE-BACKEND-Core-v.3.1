using Abstractions.Repository;
using Abstractions.Repository.Interfaces;
using Entities;
using Entities.Models;
using Entities.Models.DTO;
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


        public async Task<IQueryable<Product>> GetByNameAsync(ProductDTO product)
        {
            if (RepositoryContext.Products.Any(x => x.Name == product.Name))
            {
                return await Task.Run(() => RepositoryContext.
                               Products?.Where(p =>
                               p.Name == product.Name));
            } else return null;
        }

        public async Task<IQueryable<Product>> GetByWeightAsync(ProductDTO product)
        {
            if (RepositoryContext.Products.Any(x => x.Weight == product.Weight))
            {
                return await Task.Run(() => RepositoryContext.
                               Products?.Where(p =>
                               p.Weight == product.Weight));
            } else return null;  
        }

        public async Task<IQueryable<Product>> GetByPriceAsync(ProductDTO product)
        {
            if (RepositoryContext.Products.Any(x => x.Price == product.Price))
            {
                return await Task.Run(() => RepositoryContext.
                               Products?.Where(p =>
                               p.Price == product.Price));
            } else return null;
        }

        public IEnumerable<Product> FindByCondition(ProductDTO product)
        {
            List<Product> names = new List<Product>();
            List<Product> weights = new List<Product>();
            List<Product> prices = new List<Product>();
            List<Product> products = new List<Product>();

            if (RepositoryContext.Products.Any(x=>x.Name == product.Name))
            {
                names.AddRange(RepositoryContext.
                               Products?.Where(p =>
                               p.Name == product.Name));
            }

            if (RepositoryContext.Products.Any(x => x.Weight <= product.Weight))
            {
                weights.AddRange(RepositoryContext.
                               Products?.Where(p =>
                               p.Weight == product.Weight));
            }

            if (RepositoryContext.Products.Any(x => x.Price == product.Price))
            {
                prices.AddRange(RepositoryContext.
                               Products?.Where(p =>
                               p.Price == product.Price));
            }

            products.AddRange(names);
            products.AddRange(weights);
            products.AddRange(prices);
            var filtered = products.Where(x => x.Name == product.Name && x.Price == product.Price && x.Weight <= product.Weight);

            return filtered.Distinct();
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
