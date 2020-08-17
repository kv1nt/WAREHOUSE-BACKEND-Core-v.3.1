using Entities.IDEntity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Models
{
    [Table("NavLinks")]
    public class NavLink : IEntity
    {
        [Key]
        public Guid? Id { get; set; }
        [MaxLength(100)]
        public string Name { get; set; }
        [MaxLength(150)]
        public string LinkUrl { get; set; }
    }
}
