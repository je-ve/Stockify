using System.ComponentModel.DataAnnotations;
namespace Stockify.Web.ViewModels;

public class ProductInputModel
{
    [Required(ErrorMessage = "Serienummer is verplicht")]    
    public long SerialNumber { get; set; }


    [Required(ErrorMessage = "Naam is verplicht")]
    public string Name { get; set; }
}
