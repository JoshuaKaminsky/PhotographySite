using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Photography.Data.Entities
{
    [Table("Category")]
    internal class CategoryEntity : BaseEntity
    {
        public string Name { get; set; }
    }
}
