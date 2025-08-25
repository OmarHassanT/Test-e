using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Test_e.Server.Models
{
    public class Payment
    {
        [Key]
        public int Id { get; set; }
        
        public int OrderId { get; set; }
        public virtual Order Order { get; set; } = null!;
        
        [Required]
        public PaymentStatus Status { get; set; } 

        [Required]
        public PaymentMethod PaymentMethod { get; set; } = PaymentMethod.CashOnDelivery;
        
        [Required]
        [Column(TypeName = "decimal(10,2)")]
        public decimal Amount { get; set; }
        
        public DateTime? PaidAt { get; set; }
        
        [StringLength(255)]
        public string? Notes { get; set; }
        
        public DateTime? CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; } = DateTime.UtcNow;
    }
    /// <summary>
    ///  
    /// </summary>

    public enum PaymentMethod
    {
        CashOnDelivery = 1,
        CreditCard = 2
    }
}
