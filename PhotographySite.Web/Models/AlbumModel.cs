using Photography.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhotographySite.Models
{
    public class AlbumModel
    {
        public Album Album { get; set; }

        public List<Category> AvailableCategories { get; set; }

        public int? SelectedCategoryId { get; set; }
    }
}