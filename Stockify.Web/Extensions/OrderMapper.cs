using Stockify.Objects;
using Stockify.Web.ViewModels;
namespace Stockify.Web.Extensions;
public static class OrderMapper
{
    public static OrderViewModel ToInputModel(this Order order)
    {
        return new OrderViewModel
        {
            Id = order.Id,
            CustomerId = order.CustomerId,
            Status = order.Status,
            OrderLines = order.OrderLines.Select(ol => new OrderLineViewModel
            {
                Id = ol.Id,
                ProductId = ol.ProductId,
                Quantity = ol.Quantity
            }).ToList()
        };
    }

    public static Order ToEntity(this OrderViewModel input)
    {
        return new Order
        {
            Id = input.Id,
            CustomerId = input.CustomerId,
            Status = input.Status, 
            OrderLines = input.OrderLines.Select(ol => new OrderLine
            {
                Id = ol.Id,
                ProductId = ol.ProductId,
                Quantity = ol.Quantity,
                OrderId = input.Id
            }).ToList() ?? new List<OrderLine>()
        };
    }
}
