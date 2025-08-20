using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Test_e.Server.Models
{
    public class VariantAttributeValue
    {
        [ForeignKey("ProductVariant")]
        public int ProductVariantId { get; set; }
        public virtual ProductVariant ProductVariant { get; set; } = null!;
        
        [ForeignKey("AttributeValue")]
        public int AttributeValueId { get; set; }
        public virtual AttributeValue AttributeValue { get; set; } = null!;
      
    }
}
