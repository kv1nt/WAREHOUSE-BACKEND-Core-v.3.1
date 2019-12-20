using Entities.IDEntity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Models
{
    [Table("Company")]
    public class Company : IEntity 
    {
        [Key]
        public Guid? Id { get; set; }

        [MaxLength(300)]
        public string  Name { get; set; }

        [MaxLength(3000)]
        public string  Description { get; set; }

        //public virtual Lacation Location { get; set; }
    }
}
