using System.ComponentModel.DataAnnotations;

namespace Stockify.API.Dto;
public class ProductDto
{
    //public int Id { get; set; }

    [Required]
    public long SerialNumber { get; set; }

    [Required]
    public string Name { get; set; }

    //public virtual ICollection<StockAction> StockActions { get; set; } = new List<StockAction>();
    //public int TotalStock { get; set; }
   //public int AvailableStock { get; set; }
    //public int TotalStockActions { get; set; }
    //public DateTime? LastStockAction { get; set; }
}
