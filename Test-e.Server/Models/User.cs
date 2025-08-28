using System.ComponentModel.DataAnnotations;

namespace Test_e.Server.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [StringLength(100)]
        public string FirstName { get; set; } = string.Empty;
        
        [Required]
        [StringLength(100)]
        public string LastName { get; set; } = string.Empty;
        
        [StringLength(255)]
        public string? Email { get; set; }
        
        [Required]
        [StringLength(255)]
        public string Password { get; set; } = string.Empty;
        
        [StringLength(255)]
        public string? Phone { get; set; }
        
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        /// <summary>
        /// Indicates whether the user is a BackOffice user (managing the system)
        /// or a Customer (purchasing products).
        /// </summary>
        [Required]
        public UserType UserType { get; set; }

        [StringLength(255)]
        public string? FacebookId { get; set; }
        
        [StringLength(255)]
        public string? GoogleId { get; set; }
        
        [StringLength(255)]
        public string? Photo { get; set; }
        
        // Computed property
        public string FullName => $"{FirstName} {LastName}".Trim();
        
        // Navigation properties
        public virtual ICollection<Address> Addresses { get; set; } = new List<Address>();
        public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
        public virtual ICollection<OrderAdjustment> OrderAdjustments { get; set; } = new List<OrderAdjustment>();
        public virtual ICollection<Wishlist> Wishlists { get; set; } = new List<Wishlist>();
        public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();
        public virtual ICollection<Cart> Carts { get; set; } = new List<Cart>();
        public virtual ICollection<RecentlyViewedProduct> RecentlyViewedProducts { get; set; } = new List<RecentlyViewedProduct>();
        public virtual ICollection<Log> Logs { get; set; } = new List<Log>();
        public ICollection<UserPermission> UserPermissions { get; set; } = new List<UserPermission>();

    }
    public enum UserType
    {
        BackOffice = 0,
        Customer = 1,
    }
}
