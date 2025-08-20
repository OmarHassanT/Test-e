using System.ComponentModel.DataAnnotations;

namespace Test_e.Server.Models
{
    public class AppSetting
    {
        [Key]
        [StringLength(100)]
        public string Key { get; set; } = string.Empty;
        
        [Required]
        [StringLength(255)]
        public string Value { get; set; } = string.Empty;
    }
}
