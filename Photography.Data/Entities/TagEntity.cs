using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Photography.Data.Entities
{
    [Table("Tag")]
    internal class TagEntity : BaseEntity
    {
        public TagEntity()
        {
            Albums = new List<AlbumEntity>();
            Photos = new List<PhotoEntity>();
        }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        public virtual ICollection<AlbumEntity> Albums { get; set; }

        public virtual ICollection<PhotoEntity> Photos { get; set; }
    }
}
