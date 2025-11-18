using System.ComponentModel.DataAnnotations;

namespace UrlShortener.DTO;

public class UserRegisterModel
{
    public string Username { get; set; }
    
    [Required(ErrorMessage = "Email is required")]
    public required string Email { get; set; }
    
    [Required(ErrorMessage = "Password is required")]
    public required string Password { get; set; }
    
    [Required(ErrorMessage = "ConfirmPassword is required")]
    public required string ConfirmPassword { get; set; }
}