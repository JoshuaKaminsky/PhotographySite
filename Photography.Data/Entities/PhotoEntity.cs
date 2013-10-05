using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Photography.Data.Entities
{
    [Table("Photo")]
    internal class PhotoEntity : BaseEntity
    {
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
