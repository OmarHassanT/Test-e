using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Test_e.Server.Models
{
    public class Address
    {
        [Key]
        public int Id { get; set; }
        
        [ForeignKey("User")]
        public int? UserId { get; set; }
        public virtual User? User { get; set; }
        
        [Required]
        [StringLength(50)]
        public string FirstName { get; set; } = string.Empty;
        
        [Required]
        [StringLength(50)]
        public string LastName { get; set; } = string.Empty;
        
        [Required]
        [StringLength(255)]
        public string AddressOne { get; set; } = string.Empty;

        [Required]
        [ForeignKey("Country")]
        public int CountryId { get; set; }
        public virtual Country Country { get; set; } = null!;

        [Required]
        [ForeignKey("State")]
        public int StateId { get; set; }
        public virtual State State { get; set; } = null!;

        [Required]
        [ForeignKey("City")]
        public int CityId { get; set; }
        public virtual City City { get; set; } = null!;
       
        [Required]
        [StringLength(50)]
        public string PhoneOne { get; set; } = string.Empty;
        
        [StringLength(50)]
        public string? PhoneTwo { get; set; }
        
        [StringLength(20)]
        public string? PostalCode { get; set; }
        
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        
        // Navigation properties
        public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}
