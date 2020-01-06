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
                warehouse.Square = newWarehouse.Square;
                warehouse.Description = newWarehouse.Description;

                if(newWarehouse.LocationId != null)
                {
                    var warehouseLocation = new Lacation();
                    warehouseLocation.Id = Guid.NewGuid();
                    warehouseLocation.WarehouseId = warehouse.Id.ToString();
                    warehouseLocation.CompanyId = newWarehouse.CompanyId.ToString();
                    //warehouseLocation.Country = newWarehouse.Location.Country;
                    //warehouseLocation.City = newWarehouse.Location.City;
                    //warehouseLocation.BuildingNumber = newWarehouse.Location.BuildingNumber;
                    //warehouseLocation.Latitude = newWarehouse.Location.Latitude;
                    //warehouseLocation.Longtitude = newWarehouse.Location.Longtitude;
                    //warehouseLocation.Street = newWarehouse.Location.Street;
                    //warehouseLocation.Zip = newWarehouse.Location.Zip;

                    this.RepositoryContext.Locations.Add(warehouseLocation);
                }
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
            throw new NotImplementedException();
        }

        public IEnumerable<Warehouse> FindAllWarehouses()
        {
            return this.FindAll();
        }

        public IEnumerable<Warehouse> FindAllWarehousesByCompanyId(Guid companyId)
        {
            if(companyId != null)
            {
                return this.RepositoryContext.Warehouses.Where(x => x.CompanyId == companyId);
            }
            throw new NotImplementedException();
        }

        public Warehouse FindByCondition(Guid warehouseId)
        {
            throw new NotImplementedException();
        }

        public bool UpdateWarehouse(Warehouse entity)
        {
            throw new NotImplementedException();
        }
    }
}
