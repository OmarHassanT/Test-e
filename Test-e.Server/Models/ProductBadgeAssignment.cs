using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Test_e.Server.Models
{
    public class ProductBadgeAssignment
    {
        [Key]
        public int Id { get; set; }
        
        [ForeignKey("ProductBadge")]
        public int BadgeId { get; set; }
        public virtual ProductBadge ProductBadge { get; set; } = null!;
        
        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public virtual Product Product { get; set; } = null!;
        
        public DateOnly StartDate { get; set; }
        
        public DateOnly EndDate { get; set; }
        
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
