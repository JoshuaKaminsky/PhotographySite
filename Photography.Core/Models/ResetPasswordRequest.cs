using System;

namespace Photography.Core.Models
{
    public class ResetPasswordRequest : BaseModel
    {
        public User User { get; set; }

        public Guid Token { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? UsedOn { get; set; }
    }
}
