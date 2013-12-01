using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Photography.Data.Entities
{
    [Table("ResetPasswordRequest")]
    internal class ResetPasswordRequestEntity : BaseEntity
    {
        [Required]
        public int UserId { get; set; }

        [Required]
        public Guid Token { get; set; }

        [Required]
        public DateTime CreatedOn { get; set; }

        public DateTime? UsedOn { get; set; }
    }
}
