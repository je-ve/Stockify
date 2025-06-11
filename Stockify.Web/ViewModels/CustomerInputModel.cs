using System.ComponentModel.DataAnnotations;
namespace Stockify.Web.ViewModels;
public class CustomerInputModel
{
    [Required(ErrorMessage = "Naam is verplicht")]
    public string Name { get; set; }

    [Required]
    [RegularExpression(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", ErrorMessage = "Ongeldig e-mailadres")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Straat is verplicht")]
    public string Street { get; set; }

    [Required(ErrorMessage = "Huisnummer is verplicht")]
    [StringLength(maximumLength:5, MinimumLength =1, ErrorMessage = "Huisnummer moet tussen 1 en 5 tekens hebben.")]
    public string HouseNumber { get; set; }

    [Required(ErrorMessage = "Postcode is verplicht")]
    [RegularExpression(@"^\d{4}$", ErrorMessage = "Postcode moet exact 4 cijfers hebben.")]
    public string Zipcode { get; set; }

    [Required(ErrorMessage = "Plaats is verplicht")]
    public string City { get; set; }
}

