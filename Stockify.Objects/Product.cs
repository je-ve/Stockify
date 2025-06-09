using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public string? CreatedById { get; set; }

    [ForeignKey(nameof(CreatedById))]
    public ApplicationUser? CreatedBy { get; set; }
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

    public string? UpdatedById { get; set; }

    [ForeignKey(nameof(UpdatedById))]
    public ApplicationUser? UpdatedBy { get; set; }
}
