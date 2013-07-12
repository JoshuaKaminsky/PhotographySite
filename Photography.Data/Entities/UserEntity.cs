using System.Collections.Generic;
namespace Photography.Data.Entities
{
    internal class UserEntity : BaseEntity
    {
        public UserEntity()
        {
            Roles = new List<RoleEntity>();
        }

        public string EmailAddress { get; set; }

        public string Password { get; set; }

        public string Salt { get; set; }

        public decimal Discount { get; set; }
       
        public virtual ICollection<RoleEntity> Roles { get; set; }
    }
}
