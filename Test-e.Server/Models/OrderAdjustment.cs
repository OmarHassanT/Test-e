using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Test_e.Server.Models
{
    public class OrderAdjustment
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Order")]
        public int OrderId { get; set; }
        public virtual Order Order { get; set; } = null!;

        [ForeignKey("CreatedBy")]
        public int CreatedById { get; set; }
        public virtual User CreatedBy { get; set; } = null!;

        [ForeignKey("UpdatedBy")]
        public int? UpdatedById { get; set; }
        public virtual User? UpdatedBy { get; set; } = null!;

        [Required]
        [Column(TypeName = "varchar(20)")]
        public OrderAdjustmentType AdjustmentType { get; set; } // 'extra_cost' or 'discount'

        [Required]
        [Column(TypeName = "decimal(10,2)")]
        public decimal Amount { get; set; }

        public required string Reason { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }

    public enum OrderAdjustmentType
    {
        ExtraCost = 1,
        Discount = 2
    }
}
