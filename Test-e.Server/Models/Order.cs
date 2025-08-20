using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Test_e.Server.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        
        [ForeignKey("User")]
        public int? UserId { get; set; }
        public virtual User? User { get; set; }
        
        [ForeignKey("Address")]
        public int AddressId { get; set; }
        public virtual Address Address { get; set; } = null!;
        
        [ForeignKey("OrderStatus")]
        public int OrderStatusId { get; set; }
        public virtual OrderStatus OrderStatus { get; set; } = null!;
        
        [ForeignKey("OrderDiscount")]
        public int? OrderDiscountId { get; set; }
        public virtual OrderDiscount? OrderDiscount { get; set; }
        
        [Column(TypeName = "decimal(10,2)")]
        public decimal DeliveryPrice { get; set; } = 0.00m;
        
        [Required]
        [Column(TypeName = "decimal(10,2)")]
        public decimal Total { get; set; } // base cost of the items

        [Column(TypeName = "decimal(10,2)")]
        public decimal TotalAdjustment { get; set; } = 0.00m; //can be - or +
        
        [Column(TypeName = "decimal(10,2)")]
        public decimal? FinalTotal { get; set; } // total + delivery_price + total_adjustment - orderLevelDiscount

        [ForeignKey("DeliveryCompany")]
        public int? DeliveryCompanyId { get; set; }
        public virtual DeliveryCompany? DeliveryCompany { get; set; }
        
        [StringLength(100)]
        public string? TrackingNumber { get; set; }
      
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        
        public DateTime? ShippedAt { get; set; }
        
        public DateTime? DeliveredAt { get; set; }
        
        public DateTime? ReturnedAt { get; set; }
        
        public string? ReturnReason { get; set; }
        
        [StringLength(255)]
        public string? Note { get; set; }
        
        [ForeignKey("AssignedTo")]
        public int? AssignedToId { get; set; } // refrence user table. for the employees. ref file: Order AssignedToUserId
        public virtual User? AssignedTo { get; set; }
        
        // Navigation properties
        public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
        public virtual ICollection<OrderAdjustment> OrderAdjustments { get; set; } = new List<OrderAdjustment>();
        public virtual ICollection<OrderReturn> OrderReturns { get; set; } = new List<OrderReturn>();
        public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();
        public virtual ICollection<OrderStatusHistory> OrderStatusHistories { get; set; } = new List<OrderStatusHistory>();
    }
}
