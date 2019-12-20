using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Abstractions.Repository.Interfaces
{
    public interface ICompanyRepository : IRepository<Company>
    {
        IEnumerable<Company> FindAllCompanies();
        Company FindByCondition(Guid companyId);
        bool CreateCompany(Company entity);
        void UpdateCompany(Company entity);
        void DeleteCompany(Company entity);
    }
}
