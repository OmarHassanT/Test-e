using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Test_e.Server.Models
{
    public class OrderDiscount
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [StringLength(50)]
        public string Code { get; set; } = string.Empty;
        
        public string? Description { get; set; }
        
        [Column(TypeName = "decimal(5,2)")]
        public decimal DiscountPercent { get; set; }
        
        public DateOnly ValidFrom { get; set; }
        
        public DateOnly ValidTo { get; set; }
        
        public bool Active { get; set; } = true; //once the Code is used then must be inactive
        
        // Navigation properties
        public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}
