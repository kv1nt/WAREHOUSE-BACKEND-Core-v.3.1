using Entities.IDEntity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Models
{
    [Table("Product")]
    public class Product : BaseProduct, IEntity
    {
        [Key]
        public override Guid? Id { get; set; }
        public string PhotoId { get; set; }

        [MaxLength(100)]
        public override string Name { get; set; }

        [MaxLength(100)]
        public override string Type { get; set; }

        [MaxLength(100)]
        public override string Color { get; set; }

        [Range(0, Double.MaxValue)]
        public override decimal Weight { get; set; }

        [Range(0, Double.MaxValue)]
        public override decimal Price { get; set ; }

        [MaxLength(5000)]
        public string Description { get; set; }
    }
}
