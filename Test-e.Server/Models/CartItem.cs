using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Test_e.Server.Models
{
    public class CartItem
    {
        [Key]
        public int Id { get; set; }
        
        [ForeignKey("Cart")]
        public int CartId { get; set; }
        public virtual Cart Cart { get; set; } = null!;
        
        [ForeignKey("ProductVariant")]
        public int? ProductVariantId { get; set; }
        public virtual ProductVariant? ProductVariant { get; set; }
        
        [Required]
        public int Quantity { get; set; }
        
        [StringLength(255)]
        public string? Note { get; set; }
        
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}
