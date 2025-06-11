using System.ComponentModel.DataAnnotations;
namespace Stockify.API.Dto;
public class StockActionDto
{
    [Required]
    public int productId { get; set; }
    /// <summary>
    /// 1 for addition, -1 for subtraction.
    /// </summary>
    [Required]
    public int type { get; set; }

    [Required]
    public int quantity { get; set; }

}
