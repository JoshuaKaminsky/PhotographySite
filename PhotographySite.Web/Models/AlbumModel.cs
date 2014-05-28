using Photography.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhotographySite.Models
{
    public class AlbumModel
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public Photo AlbumCover { get; set; }

        public Category Category { get; set; }

        public bool IsPublic { get; set; }

        public DateTime CreatedOn { get; set; }

        public IEnumerable<Tag> Tags { get; set; }

        public List<Category> AvailableCategories { get; set; }
    }
}