using Abstractions.Repository;
using Abstractions.Repository.Interfaces;
using Entities;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository.Repositories
{
    public class WarehouseRepository : RepositoryBase<Warehouse>, IWarehouseRepository
    {
        public WarehouseRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {

        }

        public bool CreateWarehouse(Warehouse newWarehouse)
        {
            if(newWarehouse != null)
            {
                var warehouse = new Warehouse();
                warehouse.Id = Guid.NewGuid();
                warehouse.CompanyId = newWarehouse.CompanyId;
                warehouse.UserId = newWarehouse.UserId;
                warehouse.LocationId = newWarehouse.LocationId;
                warehouse.Square = newWarehouse.Square;
                warehouse.Description = newWarehouse.Description;

                Create(warehouse);
                return true;
            }
            else
            {
                return false;
            }
        }

        public void DeleteWarehouse(Warehouse entity)
        {
            if (entity != null)
            {
                Delete(RepositoryContext.Warehouses
                    .Where(v => v.Id == entity.Id).FirstOrDefault());
            }
        }

        public IEnumerable<Warehouse> FindAllWarehouses(string userId)
        {
            return RepositoryContext.Warehouses
                                    .Where(v => v.UserId == userId).ToList();
        }

        public IEnumerable<Warehouse> FindAllWarehousesByCompanyId(Guid companyId)
        {
            if(companyId != null)
            {
                return this.RepositoryContext.Warehouses.Where(x => x.CompanyId == companyId.ToString());
            }
            throw new NotImplementedException();
        }

        public Warehouse FindByCondition(Guid warehouseId)
        {
            if (warehouseId != null)
            {
                return RepositoryContext.Warehouses
                    .Where(v => v.Id == warehouseId).FirstOrDefault();
            }
            return null;
        }

        public bool UpdateWarehouse(Warehouse entity)
        {
            throw new NotImplementedException();
        }
    }
}
