using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abstractions.Repository.Interfaces;
using Entities.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ASPNetApp.Controllers
{
    [Route("api/warehouse")]
    [ApiController]
    public class WarehouseController : Controller
    {
        private IRepositoryWrapper _repository;


        public WarehouseController(IRepositoryWrapper repository)
        {
            _repository = repository;

        }

        [HttpGet]
        public IActionResult GetWarehouses()
        {
            try
            {
                var warehouses = _repository.WarehouseRepo.FindAllWarehouses();

                if (warehouses == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(warehouses);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpPost]
        public IActionResult CreateWarehouse([FromBody] Warehouse newWarehouse)
        {
            try
            {
                var isWarehouseCreated = _repository.WarehouseRepo.CreateWarehouse(newWarehouse);

                _repository.Save();

                if (isWarehouseCreated)
                {
                    return Ok();
                }
                else
                {
                    return BadRequest("Smth went wrong with creating warehouse");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }

        }

        [HttpGet("{companyId}")]
        [AllowAnonymous]
        public IActionResult GetWarehousesByCompanyId(Guid companyId)
        {
            try
            {
                var warehouses = _repository.WarehouseRepo.FindAllWarehousesByCompanyId(companyId);

                if (warehouses == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(warehouses);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }

        }

    }
}