using System.ComponentModel.DataAnnotations;

namespace Presentation.SpeedyRent.Resources;

public record CreateUserResource(
    [Required]
    [MinLength(3)]
    string Username,
    [Required]
    [EmailAddress]
    string Email,
    [Required]
    [MinLength(6)]
    string Password);