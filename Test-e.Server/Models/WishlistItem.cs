using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Test_e.Server.Models
{
    public class WishlistItem
    {
        [Key]
        public int Id { get; set; }
        
        [ForeignKey("Wishlist")]
        public int WishlistId { get; set; }
        public virtual Wishlist Wishlist { get; set; } = null!;
        
        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public virtual Product Product { get; set; } = null!;
        
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
