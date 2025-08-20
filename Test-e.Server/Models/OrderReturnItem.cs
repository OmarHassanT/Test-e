using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Test_e.Server.Models
{
    public class OrderReturnItem
    {
        [Key]
        public int Id { get; set; }
        
        [ForeignKey("OrderReturn")]
        public int OrderReturnId { get; set; }
        public virtual OrderReturn OrderReturn { get; set; } = null!;
        
        [ForeignKey("ProductVariant")]
        public int ProductVariantId { get; set; }
        public virtual ProductVariant ProductVariant { get; set; } = null!;
        
        [Required]
        public int Quantity { get; set; }
    }
}
