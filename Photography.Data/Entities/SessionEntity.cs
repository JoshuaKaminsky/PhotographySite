using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Photography.Data.Entities
{
    [Table("Session")]
    internal class SessionEntity : BaseEntity
    {
        [Required]
        public Guid SessionKey { get; set; }

        [ForeignKey("UserId")]
        public virtual UserEntity User { get; set; }
        [Required]
        public int UserId { get; set; }

        [Required]
        public DateTime CreatedOn { get; set; }
    }
}
