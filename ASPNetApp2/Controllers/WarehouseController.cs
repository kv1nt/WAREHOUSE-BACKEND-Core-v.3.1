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

        [HttpGet("{userId}")]
        public IActionResult GetWarehouses(string userId)
        {
            try
            {
                var warehouses = _repository.WarehouseRepo.FindAllWarehouses(userId); 

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

        [HttpDelete("{companyId}")]
        [AllowAnonymous]
        public IActionResult DeleteWarehouse(Guid companyId)
        {
            try
            {
                var warehouse = _repository.WarehouseRepo.FindByCondition(companyId);

                if (warehouse == null)
                {
                    return NotFound("Company doesn't not exists");
                }
                else
                {
                    _repository.WarehouseRepo.DeleteWarehouse(warehouse);
                    return Ok("The warehouse was deleted sycessfully");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }

        }

    }
}