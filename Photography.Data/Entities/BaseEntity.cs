using System.ComponentModel.DataAnnotations;
namespace Photography.Data.Entities
{
    internal class BaseEntity
    {
        [Key]
        public int Id { get; set; }
    }
}