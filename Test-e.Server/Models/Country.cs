using System.ComponentModel.DataAnnotations;

namespace Test_e.Server.Models
{
    public class Country
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public string Name { get; set; } = string.Empty;
        
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
        
        // Navigation properties
        public virtual ICollection<State> States { get; set; } = new List<State>();
        public virtual ICollection<DeliveryPrice> DeliveryPrices { get; set; } = new List<DeliveryPrice>();
    }
}
