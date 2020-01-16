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

        [ForeignKey("CompanyFK")]
        public string CompanyId { get; set; }

        [ForeignKey("UserId")]
        public string UserId { get; set; }

        public string LocationId { get; set; }

        [Range(0, float.MaxValue)]
        public decimal Square { get; set; }

        [MaxLength(3000)]
        public string Description { get; set; }


        //public virtual Lacation Location { get; set; }
    }
}
