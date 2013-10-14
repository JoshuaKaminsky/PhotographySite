using System;

namespace Photography.Core.Models
{
    public class Session : BaseModel
    {
        public Guid SessionKey { get; set; }

        public User User { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}
