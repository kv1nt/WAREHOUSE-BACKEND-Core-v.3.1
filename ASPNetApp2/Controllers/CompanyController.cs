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
    [ApiController]
    [Route("api/[controller]")]
    public class CompanyController : ControllerBase
    {

        private IRepositoryWrapper _repository;


        public CompanyController(IRepositoryWrapper repository)
        {
            _repository = repository;

        }

        [HttpGet]
        public IActionResult GetCompanies()
        {
            try
            {
                var companies = _repository.CompanyRepo.FindAllCompanies();

                if (companies == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(companies);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult CreateCompany([FromBody] Company newCompany)
        {
            try
            {
              var isCompanyCreated =  _repository.CompanyRepo.CreateCompany(newCompany);

                _repository.Save();

                if (isCompanyCreated)
                {
                    return Ok();
                }
                else
                {
                    return BadRequest("Smth went wrong with creating company");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }

        }

        [HttpGet("{companyId}")]
        [AllowAnonymous]
        public IActionResult GetCompanyById(Guid companyId)
        {
            try
            {
                var company = _repository.CompanyRepo.FindByCondition(companyId);

                if (company == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(company);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }

        }
    }
}