using Entities.IDEntity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Models
{
    [Table("Warehouse")]
    public class Warehouse : IEntity 
    {
        [Key]
        public Guid? Id {get; set;}

        [Required(ErrorMessage = "CompanyId is required")]
        [ForeignKey("CompanyFK")]
        public Guid? CompanyId { get; set; }

        //[Required(ErrorMessage = "LocationId is required")]
        [ForeignKey("LocationFK")]
        public Guid LocationId { get; set; }

        [Range(0, float.MaxValue)]
        public decimal Square { get; set; }

        [MaxLength(3000)]
        public string Description { get; set; }


        //public virtual Lacation Location { get; set; }
    }
}
