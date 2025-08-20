using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Test_e.Server.Models
{
    public class ProductDiscount
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("ProductVariant")]
        public int ProductVariantId { get; set; }
        public virtual ProductVariant ProductVariant { get; set; } = null!;

        [ForeignKey("Campaign")]
        public int? CampaignId { get; set; }
        public virtual Campaign? Campaign { get; set; }

        [Required]
        [StringLength(20)]
        public DiscountType DiscountType { get; set; } // 'percentage' or 'fixed'

        [Required]
        [Column(TypeName = "decimal(10,2)")]
        public decimal DiscountValue { get; set; }
        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public bool IsActive { get; set; } = true;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }

    public enum DiscountType
    {
        Percentage = 1,
        Fixed = 2
    }
}
