using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Abstractions.Repository.Interfaces
{
    public interface IWarehouseRepository : IRepository<Warehouse>
    {
        IEnumerable<Warehouse> FindAllWarehouses(string userId);
        IEnumerable<Warehouse> FindAllWarehousesByCompanyId(Guid companyId);
        Warehouse FindByCondition(Guid warehouseId);
        bool CreateWarehouse(Warehouse entity);
        bool UpdateWarehouse(Warehouse entity);
        void DeleteWarehouse(Warehouse entity);
    }
}
