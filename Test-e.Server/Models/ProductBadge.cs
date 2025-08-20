using System.ComponentModel.DataAnnotations;

namespace Test_e.Server.Models
{
    public class ProductBadge
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [StringLength(50)]
        public string Name { get; set; } = string.Empty;
        
        [StringLength(20)]
        public string? Color { get; set; }
        
        [StringLength(50)]
        public string? Icon { get; set; }
        
        public bool IsActive { get; set; } = true;
        
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
        
        // Navigation properties
        public virtual ICollection<ProductBadgeAssignment> ProductBadgeAssignments { get; set; } = new List<ProductBadgeAssignment>();
    }
}
