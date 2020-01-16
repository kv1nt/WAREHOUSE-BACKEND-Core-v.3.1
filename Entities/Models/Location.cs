using Entities.IDEntity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Models
{
    [Table("Location")]
    public class Lacation : IEntity
    {
        [Key]
        public Guid? Id { get; set; }

        [ForeignKey("CompanyFK")]
        public string CompanyId { get; set; }

        [ForeignKey("WarehouseFK")]
        public string WarehouseId { get; set; }

        [ForeignKey("UserId")]
        public string UserId { get; set; }

        [MaxLength(300)]
        public string City { get; set; }

        [MaxLength(300)]
        public string Country { get; set; }

        [MaxLength(300)]
        public string Street { get; set; }

        [Range(0, int.MaxValue)]
        public int BuildingNumber { get; set; }

        [Range(0, int.MaxValue)]
        public int Zip { get; set; }

        [Range(0, Double.MaxValue)]
        public decimal Latitude { get; set; }

        [Range(0, Double.MaxValue)]
        public decimal Longtitude { get; set; }

    }
}
