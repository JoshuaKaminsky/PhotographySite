using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Photography.Data.Entities
{
    [Table("Role")]
    internal class RoleEntity : BaseEntity
    {
        public RoleEntity()
        {
            Users = new List<UserEntity>();
        }

        [Required]
        public string Name { get; set; }

        public virtual ICollection<UserEntity> Users { get; set; }
    }
}
