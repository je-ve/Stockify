using System.ComponentModel.DataAnnotations;
namespace Stockify.Web.ViewModels;
public class EditPasswordViewModel
{
    public string Id { get; set; } = "";

    [DataType(DataType.Password)]
    [StringLength(30, MinimumLength = 6, ErrorMessage = "Wachtwoord moet minstens 6 karakters lang zijn.")]
    [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{6,}$", ErrorMessage = "Wachtwoord moet hoofdletters, kleine letters, cijfers en speciale tekens bevatten.")]
    public string Password { get; set; } = string.Empty;

    [Required]
    [DataType(DataType.Password)]
    [Compare(nameof(Password), ErrorMessage = "Passwords do not match.")]
    public string ConfirmPassword { get; set; } = string.Empty;
}