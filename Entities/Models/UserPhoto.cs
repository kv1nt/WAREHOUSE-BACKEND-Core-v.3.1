using Entities.IDEntity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Models
{
    [Table("UserPhoto")]
    public class UserPhoto : IEntity
    {
        [Key]
        public Guid? Id { get; set; }

        public string UserId { get; set; }

        public byte[] Content { get; set; }
    }
}
