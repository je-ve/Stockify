using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stockify.Objects;
public class StockAction
{
    public int Id { get; set; }
    public int ProductId { get; set; }
    [Required]
    [ForeignKey(nameof(ProductId))]
    public virtual Product Product { get; set; } = null!;
    [Required]
    public StockActionType Type { get; set; }
    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "De hoeveelheid moet minstens 1 zijn.")]
    public int Quantity { get; set; }
    public int? OrderLineId { get; set; }
    [ForeignKey(nameof(OrderLineId))]
    public virtual OrderLine? OrderLine { get; set; } = null!;
    [Required] //set nodig voor seeding?
    public DateTime CreatedAt { get;internal set; } = DateTime.UtcNow;
}