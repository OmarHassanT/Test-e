using System.ComponentModel.DataAnnotations;

namespace Test_e.Server.Models
{
    public class DeliveryCompany
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [StringLength(255)]
        public string Name { get; set; } = string.Empty;
        
        [StringLength(255)]
        public string? ContactInfo { get; set; }
        
        public string? TrackingUrlTemplate { get; set; }
        
        [StringLength(255)]
        public string? Notes { get; set; }
        
        public DateTime? CreatedAt { get; set; } = DateTime.UtcNow;
        
        // Navigation properties
        public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
        public virtual ICollection<DeliveryPrice> DeliveryPrices { get; set; } = new List<DeliveryPrice>();
    }
}
