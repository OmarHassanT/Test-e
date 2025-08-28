using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Test_e.Server.Models
{
    public class ProductAttribute
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [StringLength(255)]
        public string Name { get; set; } = string.Empty;// e.g. Color, Size, Quantity

        public int ProductId { get; set; }
        public virtual Product Product { get; set; } = null!;

        // Navigation properties
        public virtual ICollection<AttributeOption> Options { get; set; } = new List<AttributeOption>();
    }
}
