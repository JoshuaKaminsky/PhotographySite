using System.ComponentModel.DataAnnotations.Schema;
namespace Photography.Data.Entities
{
    [Table("Role")]
    internal class RoleEntity : BaseEntity
    {
        public string Name { get; set; }
    }
}
