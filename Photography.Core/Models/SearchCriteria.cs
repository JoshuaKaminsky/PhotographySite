using System.Collections.Generic;

namespace Photography.Core.Models
{
    public class SearchCriteria
    {
        public SearchCriteria()
        {
            Tags = new List<Tag>();
        }

        public string NameFilter { get; set; }

        public IEnumerable<Tag> Tags { get; set; }
    }
}
