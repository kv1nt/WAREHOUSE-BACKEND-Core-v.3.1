using System;
using System.Collections.Generic;
using System.Text;

namespace Abstractions.Repository.Interfaces
{
    public interface IRepositoryWrapper
    {
        ICompanyRepository CompanyRepo { get; }
        IWarehouseRepository WarehouseRepo { get; }
        ILocationRepository LocationRepo { get; }
        IProductRepository ProductRepo { get; }

        void Save();
    }
}
