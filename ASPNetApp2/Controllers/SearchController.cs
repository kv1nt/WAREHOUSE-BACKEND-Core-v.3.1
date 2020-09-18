using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abstractions.Repository.Interfaces;
using Entities.Models;
using Entities.Models.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using DBSearchLib;

namespace ASPNetApp2.Properties.Controllers
{
    [Route("api/productsearch")]
    [ApiController]
    public class SearchController : Controller
    {
        private IRepositoryWrapper _repository;

        public IConfiguration _Configuration { get; private set; }

        public SearchController(IRepositoryWrapper repository, IConfiguration Configuration)
        {
            _repository = repository;
            _Configuration = Configuration;
        }

        [AllowAnonymous]
        [Route("GetProductsByParams")]
        [HttpPost]
        public IActionResult GetProductsByParams([FromBody]ProductDTO product)
        {
            try
            {
                using(var serachService = new SerachService())
                {
                    var products = _repository.ProductRepo.SearchByParameters(product, this._Configuration);
                    if (products == null) return NotFound();
                    else
                        return Ok(products);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }
    }
}