using System.ComponentModel.DataAnnotations.Schema;

namespace Photography.Data.Entities
{
    [Table("Category")]
    internal class CategoryEntity : BaseEntity
    {
        public string Name { get; set; }
    }
}
