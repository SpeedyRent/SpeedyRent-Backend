using System.ComponentModel.DataAnnotations;

namespace Presentation.SpeedyRent.Resources;

public record UpdateUserResource(
    [Required]
    string Username,
    [Required]
    [EmailAddress]
    string Email);