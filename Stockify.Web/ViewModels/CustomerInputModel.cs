using System.ComponentModel.DataAnnotations;
namespace Stockify.Web.ViewModels;
public class CustomerInputModel
{
    [Required(ErrorMessage = "Naam is verplicht")]
    public string Name { get; set; }

    [Required(ErrorMessage = "Straat is verplicht")]
    public string Street { get; set; }

    [Required(ErrorMessage = "Postcode is verplicht")]
    public string Zipcode { get; set; }

    [Required(ErrorMessage = "Plaats is verplicht")]
    public string City { get; set; }
}

