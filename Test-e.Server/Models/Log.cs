using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Test_e.Server.Models
{
    public class Log
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public string EntityType { get; set; } = string.Empty; // tables, product, order, payment
        
        [Required]
        public string ActionType { get; set; } = string.Empty; // update, add, delete
        
        [ForeignKey("User")]
        public int? UserId { get; set; }
        public virtual User? User { get; set; }
        
        [Required]
        public string Message { get; set; } = string.Empty;
        
        [Required]
        public string MessageType { get; set; } = string.Empty; // info, error, warning
        
        public int? RecordId { get; set; }
        
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
