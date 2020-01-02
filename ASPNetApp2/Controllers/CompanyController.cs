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
              var company =  _repository.CompanyRepo.CreateCompany(newCompany);

                _repository.Save();

                if (company != null)
                {
                    return Ok(company);
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

        [HttpDelete("{companyId}")]
        [AllowAnonymous]
        public IActionResult DeleteCompany(Guid companyId)
        {
            try
            {
                var company = _repository.CompanyRepo.FindByCondition(companyId);

                if (company == null)
                {
                    return NotFound("Company doesn't not exists");
                }
                else
                {
                    _repository.CompanyRepo.DeleteCompany(company);
                    return Ok("The company was deleted sycessfully");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }

        }

        [HttpPut("{companyId}")]
        [AllowAnonymous]
        public IActionResult UpdateCompany(Company newCompany)
        {
            try
            {
                if (newCompany != null)
                {
                    _repository.CompanyRepo.UpdateCompany(newCompany);
                    return Ok("The company was updated sycessfully");                 
                } else
                {
                    return NotFound();
                }
            } catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }
    }
}