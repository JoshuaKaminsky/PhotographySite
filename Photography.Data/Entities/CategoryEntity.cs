using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Photography.Data.Entities
{
    [Table("Category")]
    internal class CategoryEntity : BaseEntity
    {
        [Required]
        public string Name { get; set; }
    }
}
