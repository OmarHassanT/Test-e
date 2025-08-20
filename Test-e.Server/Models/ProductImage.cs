using System.ComponentModel.DataAnnotations;

namespace Test_e.Server.Models
{
    public class ProductImage
    {
        public int Id { get; set; }

        // FK to Product
        public int ProductId { get; set; }
        public required Product Product { get; set; }

        // Optional FK to Variant (nullable → image can belong to product only)
        public int? VariantId { get; set; }
        public ProductVariant? Variant { get; set; }

        // Image details
        public required string ImageUrl { get; set; }
        public bool IsDefault { get; set; }  // For default gallery image

        // Metadata (optional)
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }

}
