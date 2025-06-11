using System.ComponentModel.DataAnnotations;
namespace Stockify.API.Dto;
public class OrderDto
{
    [Required]
    public int customerId { get; set; }

    [Required]
    public List<OrderLineDto> Lines { get; set; } = new();

}
