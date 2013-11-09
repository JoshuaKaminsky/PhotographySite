using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Photography.Data.Entities
{
    [Table("Session")]
    internal class SessionEntity : BaseEntity
    {
        public Guid SessionKey { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }
        public virtual UserEntity User { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}
