using Entities.IDEntity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Models
{
    [Table("UserModel")]
    public class UserModel : IEntity
    {
        [Key]
        public Guid? Id { get; set; }

        [MaxLength(200)]
        public string Name { get; set; }

        [MaxLength(100)]
        [Required]
        public string Email { get; set; }

        [MaxLength(100)]
        [Required]
        public string Password { get; set; }

        [MaxLength(100)]
        [Required]
        public string ConfirmPassword { get; set; }
    }
}
