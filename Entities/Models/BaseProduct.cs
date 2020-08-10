using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Models
{
    public abstract class BaseProduct
    {
        public abstract Guid? Id { get; set; }
        public abstract string Name { get; set; }
        public abstract string Type { get; set; }
        public abstract string Color { get; set; }
        public abstract decimal Weight { get; set; }
        public abstract decimal Price { get; set; }

    }
}
