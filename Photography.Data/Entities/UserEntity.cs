using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
namespace Photography.Data.Entities
{
    [Table("User")]
    internal class UserEntity : BaseEntity
    {
        public UserEntity()
        {
            Roles = new List<RoleEntity>();
        }

        public string Name { get; set; }

        public string EmailAddress { get; set; }

        public string Password { get; set; }

        public string Salt { get; set; }

        public decimal Discount { get; set; }

        public virtual ICollection<RoleEntity> Roles { get; set; }

        public virtual ICollection<AlbumEntity> Albums { get; set; }
    }
}
