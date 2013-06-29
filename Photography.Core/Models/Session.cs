using System;

namespace Photography.Core.Models
{
    public class Session
    {
        public int Id { get; set; }

        public Guid SessionKey { get; set; }

        public User User { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}
