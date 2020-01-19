using Entities.IDEntity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.Models.DTO
{
    public class UserPhotoDTO : IEntity
    {
        [Key]
        public Guid? Id { get; set; }

        public int UserId { get; set; }

        public string Content { get; set; }
    }
}
