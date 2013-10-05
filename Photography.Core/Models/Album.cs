using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Photography.Core.Models
{
    public class Album
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public Category Category { get; set; }

        public bool IsPublic { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}
