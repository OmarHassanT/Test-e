using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Test_e.Server.Models
{
    public class Product : IEntityMetaData
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [StringLength(255)]
        public string Title { get; set; } = string.Empty;
        [StringLength(255)]
        public string SubTitle { get; set; } = string.Empty;
        
        [StringLength(255)]
        public string? Description { get; set; }

        public bool IsActive { get; set; } = true;
        
        public int? CategoryId { get; set; }
        public virtual Category? Category { get; set; }
        
        public int? BrandId { get; set; }
        public virtual Brand? Brand { get; set; }

        public int CreatedById { get ; set ; }
        public User CreatedBy { get; set; } = null!;

        public int? UpdatedById { get; set; }
        public User? UpdatedBy { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; } = DateTime.UtcNow;

        // Navigation properties
        public ICollection<ProductImage> Images { get; set; } = new List<ProductImage>();
        public virtual ICollection<ProductVariant> ProductVariants { get; set; } = new List<ProductVariant>();
        public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();
        public virtual ICollection<WishlistItem> WishlistItems { get; set; } = new List<WishlistItem>();
        public virtual ICollection<RecentlyViewedProduct> RecentlyViewedProducts { get; set; } = new List<RecentlyViewedProduct>();
        public virtual ICollection<ProductTag> ProductTags { get; set; } = new List<ProductTag>();
        public virtual ICollection<ProductBadgeAssignment> ProductBadgeAssignments { get; set; } = new List<ProductBadgeAssignment>();
   }
}
