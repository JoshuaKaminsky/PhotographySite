using System;

namespace Photography.Core.Models
{
    public class Album : BaseModel
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public Photo AlbumCover { get; set; }

        public Category Category { get; set; }

        public bool IsPublic { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}
