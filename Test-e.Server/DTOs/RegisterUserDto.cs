using System.ComponentModel.DataAnnotations;

namespace Test_e.Server.DTOs
{
    public record RegisterUserDto
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "The FirstName field is required.")]
        public string FirstName { get; init; } = null!;

        [Required(AllowEmptyStrings = false, ErrorMessage = "The LastName field is required.")]
        public string LastName { get; init; } = null!;

        [Required(AllowEmptyStrings = false, ErrorMessage = "The Email field is required.")]
        [EmailAddress(ErrorMessage = "Email is not in a valid format.")]
        public string Email { get; init; } = null!;

        [Required(AllowEmptyStrings = false, ErrorMessage = "The Password field is required.")]
        public string Password { get; init; } = null!;

        public List<int>? PermissionIds { get; init; }
    }

    public record RegisterCustomerDto
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "The FirstName field is required.")]
        public string FirstName { get; init; } = null!;

        [Required(AllowEmptyStrings = false, ErrorMessage = "The LastName field is required.")]
        public string LastName { get; init; } = null!;

        [Required(AllowEmptyStrings = false, ErrorMessage = "The Phone field is required.")]
        [Phone(ErrorMessage = "Phone is not in a valid format.")]
        public string Phone { get; init; } = null!;

        [Required(AllowEmptyStrings = false, ErrorMessage = "The Password field is required.")]
        public string Password { get; init; } = null!;
    }

    public record LoginDto
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "The Email field is required.")]
        [EmailAddress(ErrorMessage = "Email is not in a valid format.")]
        public string Email { get; init; } = null!;

        [Required(AllowEmptyStrings = false, ErrorMessage = "The Password field is required.")]
        public string Password { get; init; } = null!;
    }

    public record LoginCustomerDto
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "The Phone field is required.")]
        [Phone(ErrorMessage = "Phone is not in a valid format.")]
        public string Phone { get; init; } = null!;

        [Required(AllowEmptyStrings = false, ErrorMessage = "The Password field is required.")]
        public string Password { get; init; } = null!;
    }
}
