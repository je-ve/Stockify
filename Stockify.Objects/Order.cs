using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Stockify.Objects;

//TODO: enkel orders met status OrderStatus.Created kunnen aangepast worden.
public class Order
{
    public int Id { get; set; }

    [Required]
    // public OrderStatus Status { get; internal set; } = OrderStatus.Created;
    //internal set gebruiken, en dan status automatisch aanpassen in OrderAction?
    public OrderStatus Status { get; set; } = OrderStatus.Created;
    public int CustomerId { get; set; }

    [Required]
    [ForeignKey(nameof(CustomerId))]
    public virtual Customer Customer { get; set; } = null!;

    public virtual ICollection<OrderLine> OrderLines { get; set; } = new List<OrderLine>();        //waarom nu weer initializeren op new List?
   // public virtual ICollection<OrderAction> Actions { get; set; } = new List<OrderAction>();

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public string? CreatedById { get; set; }

    [ForeignKey(nameof(CreatedById))]
    public ApplicationUser? CreatedBy { get; set; }
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

    public string? UpdatedById { get; set; }

    [ForeignKey(nameof(UpdatedById))]
    public ApplicationUser? UpdatedBy { get; set; }
}
