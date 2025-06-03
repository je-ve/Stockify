using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stockify.Objects;
public class OrderLine
{
    public int Id { get; set; }

    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "Quantity must be greater than 0.")]
    public int Quantity { get; set; }

    public int OrderId { get; set; }

    [Required]
    [ForeignKey(nameof(OrderId))]
    public virtual Order Order { get; set; } = null!;

    public int ProductId { get; set; }

    [Required]
    [ForeignKey(nameof(ProductId))]
    public virtual Product Product { get; set; } = null!;
}
