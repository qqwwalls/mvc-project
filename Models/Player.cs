using System.ComponentModel.DataAnnotations;

namespace mvc.Models;

public class Player
{
    [Required]
    [MinLength(5, ErrorMessage = "MinLength = 5")]
    public string Login { get; set; } = String.Empty;

    [Required(ErrorMessage = "Field is required")]
    [EmailAddress(ErrorMessage = "Email is invalid")]
    public string Email { get; set; } = String.Empty;

    [Required]
    public ushort Age { get; set; }
}
