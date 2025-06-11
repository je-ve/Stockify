using System.ComponentModel.DataAnnotations;
namespace Stockify.Web.ViewModels;

public class ProductInputModel
{
    [Required(ErrorMessage = "Serienummer is verplicht")]
    [RegularExpression(@"^\d{6}$", ErrorMessage = "Serienummer moet exact 6 cijfers bevatten")]
    public long SerialNumber { get; set; }


    [Required(ErrorMessage = "Naam is verplicht")]
    public string Name { get; set; }
}
