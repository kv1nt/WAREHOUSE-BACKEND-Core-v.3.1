using Entities.IDEntity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Models
{
    [Table("Login")]
    public class Login : IEntity
    {
        [Key]
        public Guid? Id { get; set; }

        [MaxLength(100)][Required]
        public string Email { get; set; }

        [MaxLength(100)][Required]
        public string Password { get; set; }
    }
}
