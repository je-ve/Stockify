using System.ComponentModel.DataAnnotations;
namespace Stockify.API.Dto;
public class CreateOrderDto
{
    [Required]
    public int customerId { get; set; }

    [Required]
    public List<CreateOrderLineDto> Lines { get; set; } = new();

}
