using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stockify.Objects;

public class OrderAction
{
    public int Id { get; set; }
    public int OrderId { get; set; }

    [Required]
    [ForeignKey(nameof(OrderId))]
    public virtual Order Order { get; set; } = null!;

    // public OrderStatus Status { get; set; }

    private OrderStatus _status;
    public OrderStatus Status
    {
        get => _status;
        set
        {
            if (Order == null) throw new InvalidOperationException("Order must be set before setting Status.");
            _status = value;
            Order.Status = value;
        }
    }
}
