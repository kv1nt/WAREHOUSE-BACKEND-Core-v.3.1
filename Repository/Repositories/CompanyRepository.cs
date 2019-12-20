using Abstractions.Repository;
using Abstractions.Repository.Interfaces;
using Entities;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository.Repositories
{
    public class CompanyRepository : RepositoryBase<Company>, ICompanyRepository
    {

        public CompanyRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public bool CreateCompany(Company newCompany)
        {
            var company = new Company();
            var companyLocation = new Lacation();

            company.Id = Guid.NewGuid();
            company.Name = newCompany.Name;
            company.Description = newCompany.Description;

            //if(newCompany.Location != null)
            //{
            //    companyLocation.Id = Guid.NewGuid();
            //    companyLocation.CompanyId = company.Id.ToString();
            //    companyLocation.Country = newCompany.Location.Country;
            //    companyLocation.City = newCompany.Location.City;
            //    companyLocation.BuildingNumber = newCompany.Location.BuildingNumber;
            //    companyLocation.Latitude = newCompany.Location.Latitude;
            //    companyLocation.Longtitude = newCompany.Location.Longtitude;
            //    companyLocation.Street = newCompany.Location.Street;
            //    companyLocation.Zip = newCompany.Location.Zip;          
            //}
            Create(company);
            //this.RepositoryContext.Locations.Add(companyLocation);
            return true;

        }

        public void DeleteCompany(Company entity)
        {
            if (entity != null)
            {
                var company = RepositoryContext.Companies
                    .Where(v => v.Id == entity.Id).FirstOrDefault();
                Delete(company);
            }
            
            
        }

        public IEnumerable<Company> FindAllCompanies()
        {
            return this.FindAll();
        }

        public Company FindByCondition(Guid companyId)
        {
            if(companyId != null)
            {
                return this.RepositoryContext.Companies
                    .Where(v => v.Id == companyId).FirstOrDefault();
            }
            return null;
        }

        public  void UpdateCompany(Company entity)
        {
            if (entity != null)
            {
                Update(entity);
            }
        }
    }
}
