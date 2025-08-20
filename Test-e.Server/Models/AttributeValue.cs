using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Test_e.Server.Models
{
    public class AttributeValue
    {
        [Key]
        public int Id { get; set; }
        
        [ForeignKey("Attribute")]
        public int AttributeId { get; set; }
        public virtual Attribute Attribute { get; set; } = null!;
        
        [Required]
        [StringLength(255)]
        public string Value { get; set; } = string.Empty;
        
        // Navigation properties
        public virtual ICollection<VariantAttributeValue> VariantAttributeValues { get; set; } = new List<VariantAttributeValue>();
    }
}
