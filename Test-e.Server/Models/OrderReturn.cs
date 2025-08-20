using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Test_e.Server.Models
{
    public class OrderReturn
    {
        [Key]
        public int Id { get; set; }
        
        [ForeignKey("Order")]
        public int OrderId { get; set; }
        public virtual Order Order { get; set; } = null!;
        
        public string? Reason { get; set; }
        
        [Required]
        [StringLength(50)]
        public string Status { get; set; } = "Requested"; // Requested, Approved, Rejected, Received, Refunded
        
        public bool IsFullReturn { get; set; }
        
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
        
        // Navigation properties
        public virtual ICollection<OrderReturnItem> OrderReturnItems { get; set; } = new List<OrderReturnItem>();
    }
}
