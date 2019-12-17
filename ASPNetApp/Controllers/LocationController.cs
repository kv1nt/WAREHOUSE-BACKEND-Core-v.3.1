using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abstractions.Repository.Interfaces;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ASPNetApp.Controllers
{
    [Route("api/location")]
    [ApiController]
    public class LocationController : Controller
    {
        private IRepositoryWrapper _repository;


        public LocationController(IRepositoryWrapper repository)
        {
            _repository = repository;
        }


        [HttpGet]
        public IActionResult GetLocations()
        {
            try
            {
                var locations = _repository.LocationRepo.FindAllLocations();

                if (locations == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(locations);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpPost]
        public IActionResult CreateLocation([FromBody] Lacation newLocation)
        {
            try
            {
                var isLocationCreated = _repository.LocationRepo.CreateLocation(newLocation);

                _repository.Save();

                if (isLocationCreated)
                {
                    return Ok();
                }
                else
                {
                    return BadRequest("Smth went wrong with creating location");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }

        }
    }
}