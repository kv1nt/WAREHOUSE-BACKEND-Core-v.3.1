using Abstractions.Repository.Interfaces;
using Entities;
using Microsoft.EntityFrameworkCore;
using Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private readonly RepositoryContext repoContext;
        public ICompanyRepository companyRepo;
        public IWarehouseRepository warehouseRepo;
        public ILocationRepository locationRepo;

        public RepositoryWrapper(RepositoryContext repositoryContext)
        {
            this.repoContext = repositoryContext;
            repositoryContext.Database.Migrate();
        }

        public ICompanyRepository CompanyRepo
        {
            get
            {
                if(companyRepo == null)
                {
                    companyRepo = new CompanyRepository(repoContext);
                }
                return companyRepo;
            }
        }

        public IWarehouseRepository WarehouseRepo
        {
            get
            {
                if (warehouseRepo == null)
                {
                    warehouseRepo = new WarehouseRepository(repoContext);
                }
                return warehouseRepo;
            }
        }

        public ILocationRepository LocationRepo
        {
            get
            {
                if (locationRepo == null)
                {
                    locationRepo = new LocationRepository(repoContext);
                }
                return locationRepo;
            }
        }

        public void Save()
        {
            repoContext.SaveChanges();
        }
    }
}
