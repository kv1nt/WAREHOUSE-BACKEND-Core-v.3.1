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

        public Company CreateCompany(Company newCompany)
        {
            var company = new Company();

            company.Id = Guid.NewGuid();
            company.UserId = newCompany.UserId;
            company.Name = newCompany.Name;
            company.Description = newCompany.Description;

            Create(company);
            return company;

        }

        public void DeleteCompany(Company entity)
        {
            if (entity != null)
            {
                Delete(RepositoryContext.Companies
                    .Where(v => v.Id == entity.Id).FirstOrDefault());
            }
        }

        public IEnumerable<Company> FindAllCompanies(string userId)
        {
            return RepositoryContext.Companies
                                    .Where(v => v.UserId == userId).ToList();
        }

        public IEnumerable<Company> FindAllCompanies()
        {
            throw new NotImplementedException();
        }

        public Company FindByCondition(Guid companyId)
        {
            if(companyId != null)
            {
                return RepositoryContext.Companies
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
