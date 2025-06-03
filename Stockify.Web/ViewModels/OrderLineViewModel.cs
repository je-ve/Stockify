using System.ComponentModel.DataAnnotations;
namespace Stockify.Web.ViewModels;
public class OrderLineViewModel
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Product is verplicht.")]
    public int ProductId { get; set; }

    [Required(ErrorMessage = "Aantal is verplicht.")]
    [Range(1, int.MaxValue, ErrorMessage = "Aantal moet groter zijn dan 0.")]
    public int Quantity { get; set; }
}
