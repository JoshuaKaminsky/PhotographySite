using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Photography.Data.Entities
{
    [Table("Album")]
    internal class AlbumEntity : BaseEntity
    {
        public string Name { get; set; }

        public string Description { get; set; }

        [ForeignKey("AlbumCover")] // name of the session property that gets populated from this foreign key
        public int AlbumCoverId { get; set; }

        public PhotoEntity AlbumCover { get; set; }

        [ForeignKey("Category")] // name of the session property that gets populated from this foreign key
        public int CategoryId { get; set; }

        public CategoryEntity Category { get; set; }

        public bool IsPublic { get; set; }

        public DateTime CreatedOn { get; set; }

        public virtual ICollection<TagEntity> Tags { get; set; }

        public virtual ICollection<PhotoEntity> Photos { get; set; }

        public virtual ICollection<UserEntity> Users { get; set; }
    }
}
