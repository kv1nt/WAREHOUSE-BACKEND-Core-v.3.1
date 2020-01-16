using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Abstractions.Repository.Interfaces
{
    public interface ICompanyRepository : IRepository<Company>
    {
        IEnumerable<Company> FindAllCompanies(string userId);
        Company FindByCondition(Guid id);
        Company CreateCompany(Company entity);
        void UpdateCompany(Company entity);
        void DeleteCompany(Company entity);
    }
}
