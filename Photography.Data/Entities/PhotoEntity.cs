using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Photography.Data.Entities
{
    [Table("Photo")]
    internal class PhotoEntity : BaseEntity
    {
        public PhotoEntity()
        {
            Albums = new List<AlbumEntity>();
            Tags = new List<TagEntity>();
        }
        public string Name { get; set; }

        public string Description { get; set; }

        public string Source { get; set; }

        public string ThumbnailSource { get; set; }

        public bool IsPublic { get; set; }

        public DateTime CreatedOn { get; set; }

        public virtual ICollection<AlbumEntity> Albums { get; set; }

        public virtual ICollection<TagEntity> Tags { get; set; }
    }
}
