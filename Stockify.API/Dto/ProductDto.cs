using System.ComponentModel.DataAnnotations;

namespace Stockify.API.Dto;
public class ProductDto
{
    //public int Id { get; set; }

    [Required]
    public long SerialNumber { get; set; }

    [Required]
    public string Name { get; set; }
}
