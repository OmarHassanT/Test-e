using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Test_e.Server.Models
{
    public class OrderStatusHistory
    {
        [Key]
        public int Id { get; set; }
        
        [ForeignKey("Order")]
        public int OrderId { get; set; }
        public virtual Order Order { get; set; } = null!;
        
        [ForeignKey("NewStatus")]
        public int NewStatusId { get; set; }
        public virtual OrderStatus NewStatus { get; set; } = null!;
        
        [ForeignKey("ChangedBy")]
        public int? ChangedBy { get; set; }
        public virtual User? ChangedByUser { get; set; }
        
        [Required]
        public DateTime ChangedAt { get; set; } = DateTime.UtcNow;
        
        [StringLength(255)]
        public string? Note { get; set; }
    }
}
