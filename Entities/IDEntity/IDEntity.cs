using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Entities.IDEntity
{
    public interface IEntity
    {
        Guid? Id { get; }
    }
}
