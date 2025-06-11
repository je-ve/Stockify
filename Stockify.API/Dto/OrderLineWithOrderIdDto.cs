using System.ComponentModel.DataAnnotations;
namespace Stockify.API.Dto;

public class OrderLineWithOrderIdDto
{
    [Required]
    public int OrderId { get; set; }

    [Required]
    public int ProductId { get; set; }

    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "Quantity must be greater than 0.")]
    public int Quantity { get; set; }
}
