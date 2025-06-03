using Stockify.Objects;
using System.ComponentModel.DataAnnotations;
namespace Stockify.Web.ViewModels;

public class OrderViewModel
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Klant is verplicht.")]
    public int CustomerId { get; set; }

    public Customer? Customer { get; set; }


    public OrderStatus Status { get; set; } = OrderStatus.Created;

    public List<OrderLineViewModel> OrderLines { get; set; } = new();
}

