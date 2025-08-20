using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Test_e.Server.Models
{
    public class DeliveryPrice
    {
        [Key]
        public int Id { get; set; }
        
        [ForeignKey("City")]
        public int? CityId { get; set; }
        public virtual City? City { get; set; }
        
        [ForeignKey("State")]
        public int? StateId { get; set; }
        public virtual State? State { get; set; }
        
        [ForeignKey("Country")]
        public int? CountryId { get; set; }
        public virtual Country? Country { get; set; }
        
        [Required]
        [Column(TypeName = "decimal(10,2)")]
        public decimal Price { get; set; }
        
        [ForeignKey("DeliveryCompany")]
        public int? DeliveryCompanyId { get; set; }
        public virtual DeliveryCompany? DeliveryCompany { get; set; }
        
        public bool IsActive { get; set; } = true;
    }
}
