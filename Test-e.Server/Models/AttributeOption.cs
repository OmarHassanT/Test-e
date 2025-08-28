using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Test_e.Server.Models
{
    public class AttributeOption
    {
        [Key]
        public int Id { get; set; }
        
        public int AttributeId { get; set; }
        public virtual ProductAttribute Attribute { get; set; } = null!;

        [Required]
        [StringLength(255)]
        public string Value { get; set; } = string.Empty; // e.g. Red, White, 1-10
        public string? ExplanationNote { get; set; } // Note appear if the customer select this option like if select color then show the Note "Red color good one"

        // Navigation properties

    }
}
