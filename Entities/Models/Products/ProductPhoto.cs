using Entities.IDEntity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Models.Products
{
    [Table("ProductPhoto")]
    public class ProductPhoto : IEntity
    {
        [Key]
        public Guid? Id { get; set; }
        public string ProductId { get; set; }
        public byte[] Content { get; set; }
    }
}
