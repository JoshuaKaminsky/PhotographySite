using System.Collections.Generic;
namespace Photography.Data.Entities
{
    internal class UserEntity : BaseEntity
    {
        public string EmailAddress { get; set; }

        public string Password { get; set; }

        public string Salt { get; set; }

<<<<<<< HEAD
        public decimal Discount { get; set; }
=======
        public virtual ICollection<RoleEntity> Roles { get; set; }
>>>>>>> f843b154ce29c10f8d398f769d6cf9a11df378ba
    }
}
