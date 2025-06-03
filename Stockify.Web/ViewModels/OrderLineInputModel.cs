using System.ComponentModel.DataAnnotations;
namespace Stockify.Web.ViewModels;
public class OrderLineInputModel
{
    public int Id { get; set; } = 0;

    [Required(ErrorMessage = "Kies een product.")]
    [Range(1, int.MaxValue, ErrorMessage = "Kies een product")]
    public int ProductId { get; set; }

    [Required(ErrorMessage = "Aantal is verplicht.")]
    //[Range(1, int.MaxValue, ErrorMessage = "Aantal moet groter zijn dan 0.")]
    public int Quantity { get; set; }
}
