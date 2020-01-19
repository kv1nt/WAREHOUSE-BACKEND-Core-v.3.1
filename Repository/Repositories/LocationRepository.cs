using Abstractions.Repository;
using Abstractions.Repository.Interfaces;
using Entities;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Repository.Repositories
{
    public class LocationRepository : RepositoryBase<Lacation>, ILocationRepository
    {
        public LocationRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public bool CreateLocation(Lacation newLocation)
        {
            if(newLocation != null)
            {
                var location = new Lacation();

                location.Id = Guid.NewGuid();
                location.UserId = newLocation.UserId;
                location.CompanyId = newLocation.Id.ToString();
                location.Country = newLocation.Country;
                location.City = newLocation.City;
                location.BuildingNumber = newLocation.BuildingNumber;
                location.Latitude = newLocation.Latitude;
                location.Longtitude = newLocation.Longtitude;
                location.Street = newLocation.Street;
                location.Zip = newLocation.Zip;
                Create(location);
                return true;
            }
            else
            {
                return false;
            }
        }

        public void DeleteLocation(Lacation entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Lacation> FindAllLocations(string userId)
        {
            return RepositoryContext.Locations
                                    .Where(v => v.UserId == userId).ToList();
        }

        public Lacation FindByCondition(Guid id)
        {
            throw new NotImplementedException();
        }

        public bool UpdateLocation(Lacation entity)
        {
            throw new NotImplementedException();
        }
    }
}
