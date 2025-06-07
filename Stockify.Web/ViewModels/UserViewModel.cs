using System.ComponentModel.DataAnnotations;
namespace Stockify.Web.ViewModels;
public class UserViewModel
{
    public string Id { get; set; } = "";

    [Required(ErrorMessage = "Email is verplicht")]
    [EmailAddress(ErrorMessage = "Ongeldig e-mailadres")]
    public string Email { get; set; }
    
}