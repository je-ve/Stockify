using Microsoft.EntityFrameworkCore;
using Stockify.Data;
using Stockify.Objects;

namespace Stockify.Logic;

/// <summary>
/// Service to handle high-level order actions such as Delivery, Cancellation, and Deletion.
/// Modifies related stock actions and updates order status accordingly.
/// </summary>
public class OrderActionService : IOrderActionService
{
    private readonly StockifyContext _context;
    private readonly IStockActionService stockActionService;
    private readonly IProductService productService;
    private readonly IOrderService orderService;
    private readonly IOrderLineService orderLineService;
    private readonly IEmailService emailService;

    public OrderActionService(
        StockifyContext context,
        IStockActionService stockActionService,
        IProductService productService,
        IOrderService orderService,
        IOrderLineService orderLineService,
        IEmailService emailService)
    {
        _context = context;
        this.stockActionService = stockActionService;
        this.productService = productService;
        this.orderService = orderService;
        this.orderLineService = orderLineService;
        this.emailService = emailService;
    }

    /// <summary>
    /// Executes an action (Delivery, Cancel, or Delete) on an order.
    /// Applies business rules and modifies stock and order records accordingly.
    /// Sends email to customer
    /// </summary>
    public async Task CreateOrderAction(int orderId, OrderActionType type, string? userId = null)
    {
        // Fetch order with necessary related data
        var order = await _context.Orders
            .Include(o => o.Customer)
            .Include(o => o.OrderLines)
                .ThenInclude(ol => ol.Product)
            .FirstOrDefaultAsync(o => o.Id == orderId);

        if (order == null)
            throw new InvalidOperationException($"Order with ID {orderId} not found.");

        // === DELIVERY ACTION ===
        if (type == OrderActionType.Delivery)
        {
            // Send confirmation email with invoice/attachment
            await emailService.SendEmailWithAttachmentAsync(order);

            // Only new orders can be delivered
            if (order.Status != OrderStatus.Created)
                throw new InvalidOperationException($"Order with ID {orderId} is not a new order.");

            // Convert all reservation stock actions to reductions
            foreach (var line in order.OrderLines)
            {
                var stockAction = await stockActionService.GetByOrderLineIdAsync(line.Id);
                if (stockAction == null)
                    throw new InvalidOperationException($"Stock action for order line {line.Id} not found.");

                stockAction.Type = StockActionType.Reduction;
                await productService.RecalculateStock(stockAction.ProductId);
            }

            order.Status = OrderStatus.Delivered;
        }

        // === CANCEL ACTION ===
        if (type == OrderActionType.Cancel)
        {
            // Only new orders can be cancelled
            if (order.Status != OrderStatus.Created)
                throw new InvalidOperationException($"Order with ID {orderId} is not a new order.");

            foreach (var line in order.OrderLines.ToList())
            {
                var stockAction = await stockActionService.GetByOrderLineIdAsync(line.Id);
                                
                if (stockActionService == null)
                    throw new InvalidOperationException($"StockAction service is null");

                if (stockAction != null)
                {
                    await stockActionService.DeleteAsync(stockAction.Id);
                    await productService.RecalculateStock(stockAction.ProductId);
                }
            }

            order.Status = OrderStatus.Cancelled;
        }

        // === DELETE ACTION ===
        if (type == OrderActionType.Delete)
        {
            // Delivered orders cannot be deleted
            if (order.Status == OrderStatus.Delivered)
                throw new InvalidOperationException($"Order with ID {orderId} is already delivered.");

            // Delegates deletion logic to OrderService (removes stock actions, lines, and order)
            await orderService.DeleteAsync(order.Id);
        }

        // Record the performed action for audit/history
        var action = new OrderAction
        {
            OrderId = orderId,
            ActionType = type
        };

        _context.OrderActions.Add(action);
        await _context.SaveChangesAsync();
    }
}



/*
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

*/