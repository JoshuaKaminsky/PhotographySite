using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Photography.Data.Entities
{
    [Table("User")]
    internal class UserEntity : BaseEntity
    {
        public UserEntity()
        {
            Albums = new List<AlbumEntity>();
            Roles = new List<RoleEntity>();
        }

        [Required]
        public string Name { get; set; }

        [Required]
        public string EmailAddress { get; set; }

        [Required]
        public byte[] Password { get; set; }

        [Required]
        public string Salt { get; set; }

        public decimal? Discount { get; set; }

        public bool IsActive { get; set; }

        public virtual ICollection<RoleEntity> Roles { get; set; }

        public virtual ICollection<AlbumEntity> Albums { get; set; }
    }
}
