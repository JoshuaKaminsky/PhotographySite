using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        [Required]
        public string Source { get; set; }

        [Required]
        public string ThumbnailSource { get; set; }

        [Required]
        public bool IsPublic { get; set; }

        [Required]
        public DateTime CreatedOn { get; set; }

        public virtual ICollection<AlbumEntity> Albums { get; set; }

        public virtual ICollection<TagEntity> Tags { get; set; }
    }
}
