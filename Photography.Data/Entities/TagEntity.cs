using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Photography.Data.Entities
{
    [Table("Tag")]
    internal class TagEntity : BaseEntity
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public virtual ICollection<AlbumEntity> Albums { get; set; }

        public virtual ICollection<PhotoEntity> Photos { get; set; }
    }
}
