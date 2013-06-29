using System;

namespace Photography.Data.Entities
{
    internal class SessionEntity : BaseEntity
    {
        public Guid SessionKey { get; set; }

        public int UserId { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}
