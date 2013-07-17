using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Photography.Data.Entities
{
    [Table("Session")]
    internal class SessionEntity : BaseEntity
    {
        public Guid SessionKey { get; set; }

        [ForeignKey("User")] // name of the session property that gets populated from this foreign key
        public int UserId { get; set; }

        public UserEntity User { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}
