using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abstractions.Repository.Interfaces;
using Entities.Models.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ASPNetApp2.Controllers
{
    [Route("api/product")]
    [ApiController]
    public class ProductController : Controller
    {
        private IRepositoryWrapper _repository;
        public ProductController(IRepositoryWrapper repository)
        {
            _repository = repository;
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult GetProducts()
        {
            try
            {
                var allProducts = _repository.ProductRepo.FindAllProducts();

                if (allProducts == null) return NotFound();
                else
                    return Ok(allProducts);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [AllowAnonymous]
        [HttpGet("productId")]
        public IActionResult GetProduct(string productId)
        {
            try
            {
                var product = _repository.ProductRepo.FindByCondition(Guid.Parse(productId));

                if (product == null) return NotFound();
                else
                    return Ok(product);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult CreateProduct([FromBody] ProductDTO newProduct)
        {
            try
            {
                var isProductCreated = _repository.ProductRepo.CreateProduct(newProduct);

                _repository.Save();

                if (isProductCreated) return Ok();
                else
                    return BadRequest("Smth went wrong with creating product");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }

        }
    }
}