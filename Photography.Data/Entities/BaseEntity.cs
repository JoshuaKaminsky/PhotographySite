using System.ComponentModel.DataAnnotations;
namespace Photography.Data.Entities
{
    internal class BaseEntity
    {
        [Key]
        [Required]
        public int Id { get; set; }
    }
}