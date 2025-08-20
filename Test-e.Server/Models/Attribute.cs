using System.ComponentModel.DataAnnotations;

namespace Test_e.Server.Models
{
    public class Attribute
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [StringLength(255)]
        public string Name { get; set; } = string.Empty;
        
        // Navigation properties
        public virtual ICollection<AttributeValue> AttributeValues { get; set; } = new List<AttributeValue>();
    }
}
