using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Test_e.Server.Models
{
    public class ProductVariantOption
    {
        public int ProductVariantId { get; set; }
        public int AttributeOptionId { get; set; }

        public virtual ProductVariant ProductVariant { get; set; } = null!;
        public virtual AttributeOption AttributeOption { get; set; } = null!;
      
    }
}
