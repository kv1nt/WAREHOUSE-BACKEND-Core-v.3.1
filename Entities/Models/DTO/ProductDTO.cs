using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Models.DTO
{
    public class ProductDTO
    {
        public  Guid? Id { get; set; }
        public  string PhotoId { get; set; }
        public  string Name { get; set; }
        public  string Type { get; set; }
        public  string Color { get; set; }
        public  decimal? Weight { get; set; }
        public  decimal? Price { get; set; }
        public  string Description { get; set; }
    }
}
