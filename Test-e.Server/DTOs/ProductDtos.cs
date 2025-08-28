using System.ComponentModel.DataAnnotations;

namespace Test_e.Server.DTOs
{
    public record CreateProductRequestDto
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "The Title field is required.")]
        public string Title { get; init; } = null!;

        public string? SubTitle { get; init; }
        public string? Description { get; init; }

        [Required(ErrorMessage = "The Category field is required.")]
        public int CategoryId { get; set; }
        public int? BrandId { get; set; }

        public bool IsActive { get; set; } = true;

    }
    public record CreateProductResponseDto
    {
        public string Title { get; init; } = null!;

        public string? SubTitle { get; init; }
        public string? Description { get; init; }
        public int CategoryId { get; set; }
        public int? BrandId { get; set; }

        public bool IsActive { get; set; } = true;

    }

    public record AddOrUpdateAttributeWithOptionsDto(
        string Name,
        List<AttributeOptionDto> Options, //e.g. [{ Value: "Red", Note: "Red color good one" }]
        int? AttributeId = null// if Null then Add else Update
    );

    public record AttributeOptionDto(
        string Value,          // e.g. "Red"
        string? ExplanationNote = null    // e.g. "Red color good one"
    );
}
