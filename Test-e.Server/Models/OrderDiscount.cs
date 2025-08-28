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

        [Required]
        [StringLength(20)]
        public DiscountType DiscountType { get; set; } // 'percentage' or 'fixed'

        [Required]
        [Column(TypeName = "decimal(10,2)")]
        public decimal DiscountValue { get; set; }

        /// <summary>
        /// If null then no limit for using the discount code
        /// </summary>
        public int? NumberOfUsage { get; set; }
        /// <summary>
        /// The discount code is working for order greater than this field value
        /// </summary>
        [Column(TypeName = "decimal(10,2)")]
        public decimal MinimumOrderTotalPrice { get; set; } = 0.0M;

        public DateOnly ValidFrom { get; set; }
        
        public DateOnly ValidTo { get; set; }
        
        public bool Active { get; set; } = true; //once the Code is used then must be inactive
        public string? AdministratorNote { get; set; }
        // Navigation properties
        public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

        
    }
}
