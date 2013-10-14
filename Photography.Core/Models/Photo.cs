using System;
using System.Collections.Generic;

namespace Photography.Core.Models
{
    public class Photo : BaseModel
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string Source { get; set; }

        public string ThumbnailSource { get; set; }

        public bool IsPublic { get; set; }

        public DateTime CreatedOn { get; set; }

        public IEnumerable<Tag> Tags { get; set; }
    }
}
