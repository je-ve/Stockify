using System.ComponentModel.DataAnnotations;
namespace Stockify.Web.ViewModels;

public class EditUserViewModel
{
    public string Id { get; set; } = "";

    [Required(ErrorMessage = "Email is verplicht")]
    [RegularExpression(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", ErrorMessage = "Ongeldig e-mailadres")]
    public string Email { get; set; }
}
