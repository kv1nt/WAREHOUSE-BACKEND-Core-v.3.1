using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Abstractions.Repository.Interfaces
{
    public interface ILocationRepository : IRepository<Lacation>
    {
        IEnumerable<Lacation> FindAllLocations();
        Lacation FindByCondition(Guid id);
        bool CreateLocation(Lacation entity);
        bool UpdateLocation(Lacation entity);
        void DeleteLocation(Lacation entity);
    }
}
