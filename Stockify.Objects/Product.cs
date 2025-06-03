using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Stockify.Objects;
public class Product
{
    public int Id { get; set; }

    [Required]
    public long SerialNumber { get; set; }

    [Required]
    public string Name { get; set; }
    public virtual ICollection<StockAction> StockActions { get; set; } = new List<StockAction>();
    public int TotalStock { get; set; }
    public int AvailableStock { get; set; }
    public int TotalStockActions { get; set; }
    public DateTime? LastStockAction { get; set; }
}
