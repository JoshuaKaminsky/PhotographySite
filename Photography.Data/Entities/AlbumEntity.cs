using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Photography.Data.Entities
{
    [Table("Album")]
    internal class AlbumEntity : BaseEntity
    {
        public AlbumEntity()
        {
            Tags = new List<TagEntity>();
            Photos = new List<PhotoEntity>();
            Users = new List<UserEntity>();
        }
        public string Name { get; set; }

        public string Description { get; set; }

        [ForeignKey("AlbumCoverId")]
        public virtual PhotoEntity AlbumCover { get; set; }
        public int? AlbumCoverId { get; set; }

        [ForeignKey("CategoryId")]
        public virtual CategoryEntity Category { get; set; }
        public int CategoryId { get; set; }

        public bool IsPublic { get; set; }

        public DateTime CreatedOn { get; set; }

        public virtual ICollection<TagEntity> Tags { get; set; }

        public virtual ICollection<PhotoEntity> Photos { get; set; }

        public virtual ICollection<UserEntity> Users { get; set; }
    }
}
