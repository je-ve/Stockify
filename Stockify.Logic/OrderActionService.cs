// Interface
using Microsoft.EntityFrameworkCore;
using Stockify.Data;
using Stockify.Objects;

namespace Stockify.Logic;

public class OrderActionService : IOrderActionService
{
    private readonly StockifyContext _context;
    private readonly IStockActionService stockActionService;
    private readonly IProductService productService;
    private readonly IOrderService orderService;
    private readonly IOrderLineService orderLineService;
    private readonly IEmailService emailService;
    public OrderActionService(StockifyContext context, IStockActionService stockActionService, IProductService productService, IOrderService orderService, IOrderLineService orderLineService, IEmailService emailService)
    {
        _context = context;
        this.stockActionService = stockActionService;
        this.productService = productService;
        this.orderService = orderService;
        this.orderLineService = orderLineService;
        this.emailService = emailService;
    }

    public async Task CreateOrderAction(int orderId, OrderActionType type, string? userId = null)
    {
        var order = await _context.Orders
            .Include(o => o.Customer)
            .Include(o => o.OrderLines)
                .ThenInclude(ol => ol.Product)
            .FirstOrDefaultAsync(o => o.Id == orderId);

        if (order == null) throw new InvalidOperationException($"Order with ID {orderId} not found.");

        //Leveren
        //status aanpassen, stockacties aanpassen
        if (type == OrderActionType.Delivery)
        {
            await emailService.SendEmailWithAttachmentAsync(order);        

            //Enkel nieuwe orders kunnen geleverd worden
            if (order.Status != OrderStatus.Created) throw new InvalidOperationException($"Order with ID {orderId} is not a new order.");

            foreach (var line in order.OrderLines)
            {
                StockAction stockAction = await stockActionService.GetByOrderLineIdAsync(line.Id);
                if (stockAction == null) throw new InvalidOperationException($"Stock action for order line {line.Id} not found.");
                stockAction.Type = StockActionType.Reduction;
                await productService.RecalculateStock(stockAction.ProductId);
            }
            order.Status = OrderStatus.Delivered;
        }


        //Annuleren
        //status aanpassen, stockacties verwijderen
        if (type == OrderActionType.Cancel)
        {
            //Enkel nieuwe orders kunnen geannulleerd worden
            if (order.Status != OrderStatus.Created) throw new InvalidOperationException($"Order with ID {orderId} is not a new order.");
            foreach (var line in order.OrderLines.ToList())
            {
                StockAction stockAction = await stockActionService.GetByOrderLineIdAsync(line.Id);
                if (stockActionService == null) throw new InvalidOperationException($"Stockaction service is null");
                if (stockAction != null)// throw new InvalidOperationException($"Stock action for order line {line.Id} not found.")
                {
                    await stockActionService.DeleteAsync(stockAction.Id);
                    await productService.RecalculateStock(stockAction.ProductId);
                }


            }
            order.Status = OrderStatus.Cancelled;
        }

        //Verwijderen
        //stockacties, orderlijnen, order verwijderen, dit gebeurt in de orderAction service
        if (type == OrderActionType.Delete)
        {
            if (order.Status == OrderStatus.Delivered) throw new InvalidOperationException($"Order with ID {orderId} is already delivered.");
            await orderService.DeleteAsync(order.Id);
        }


        var action = new OrderAction
        {
            OrderId = orderId,
            ActionType = type
        };
        _context.OrderActions.Add(action);
        await _context.SaveChangesAsync();
    }
}