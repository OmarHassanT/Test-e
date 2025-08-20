using System.ComponentModel.DataAnnotations.Schema;

namespace Test_e.Server.Models
{
    public interface IEntityMetaData
    {
        int CreatedById { get; set; }
        User CreatedBy { get; set; }

        int? UpdatedById { get; set; }
        User? UpdatedBy { get; set; }

        DateTime CreatedAt { get; set; }
        DateTime? UpdatedAt { get; set; }
    }
}
