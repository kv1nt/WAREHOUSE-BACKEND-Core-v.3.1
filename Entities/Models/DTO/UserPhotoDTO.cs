using Entities.IDEntity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.Models.DTO
{
    public class UserPhotoDTO
    {
        public string  Id { get; set; }
        public string UserId { get; set; }
        public string Content { get; set; }
    }
}
