using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Photography.Data.Entities
{
    [Table("Session")]
    internal class SessionEntity : BaseEntity
    {
        public Guid SessionKey { get; set; }

        [ForeignKey("UserId")]
        public virtual UserEntity User { get; set; }
        public int UserId { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}
