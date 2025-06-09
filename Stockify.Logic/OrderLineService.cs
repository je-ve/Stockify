// Interface
using Microsoft.EntityFrameworkCore;
using Stockify.Data;
using Stockify.Objects;
namespace Stockify.Logic;

public class OrderLineService : IOrderLineService
{
    private readonly StockifyContext _context;
    private readonly IStockActionService stockActionService;
    public OrderLineService(StockifyContext context, IStockActionService stockActionService)
    {
        _context = context;
        this.stockActionService = stockActionService;
    }

    public async Task<List<OrderLine>> GetAllAsync() => await _context.OrderLines
        .Include(ol => ol.Order)
        .Include(ol => ol.Product)
        .ToListAsync();

    public async Task<OrderLine?> GetByIdAsync(int id) => await _context.OrderLines
        .Include(ol => ol.Order)
        .Include(ol => ol.Product)
        .FirstOrDefaultAsync(ol => ol.Id == id);

    public async Task AddAsync(OrderLine line, string currentUserId)
    {
        Order order = await _context.Orders.Include(o => o.OrderLines).FirstOrDefaultAsync(o => o.Id == line.OrderId);
        if (order.Status != OrderStatus.Created)
        {
            throw new InvalidOperationException("Only order lines from orders with status 'Created' can be deleted.");
        }
        order.UpdatedAt = DateTime.UtcNow;
        order.UpdatedById = currentUserId;
        _context.OrderLines.Add(line);

        await _context.SaveChangesAsync();
        await stockActionService.AddReservation(line);
        
    }

    public async Task DeleteAsync(OrderLine line)
    {
        if (line.Order.Status != OrderStatus.Created)
        {
            throw new InvalidOperationException("Only order lines from orders with status 'Created' can be deleted.");
        }
        await stockActionService.DeleteReservation(line);
        // Remove the order line from the context

        _context.OrderLines.Remove(line);
        await _context.SaveChangesAsync();

    }

    public async Task DeleteAsync(int id)
    {
        var line = await _context.OrderLines.FindAsync(id);
        if (line != null)
        {
            await DeleteAsync(line);            
        }
    }

    public async Task UpdateAsync(int id, string currentUserId)
    {
        var line = await _context.OrderLines.FindAsync(id);
        if (line != null)
        {
            await UpdateAsync(line, currentUserId);
        }
    }

    public async Task UpdateAsync(OrderLine updatedLine, string currentUserId)
    {
        Order order = await _context.Orders.Include(o => o.OrderLines).FirstOrDefaultAsync(o => o.Id == updatedLine.OrderId);

        if (updatedLine.Order.Status != OrderStatus.Created)
        {
            throw new InvalidOperationException("Only order lines from orders with status 'Created' can be deleted.");
        }
              
        order.UpdatedAt = DateTime.UtcNow;
        order.UpdatedById = currentUserId;        

        await stockActionService.UpdateReservation(updatedLine);
        _context.OrderLines.Update(updatedLine);        
        await _context.SaveChangesAsync();        
    }
}

/*

        //public async Task AddAsync(OrderLine line)
//{
//    // Load the related order and product with stock actions
//    var order = await _context.Orders
//        .FirstOrDefaultAsync(o => o.Id == line.OrderId);

//    if (order == null)
//        throw new InvalidOperationException("Order not found.");

//    if (order.Status != OrderStatus.Created)
//        throw new InvalidOperationException("Only orders with status 'Created' can have new stock reserved.");

//    var product = await _context.Products
//        .Include(p => p.StockActions)
//        .FirstOrDefaultAsync(p => p.Id == line.ProductId);

//    if (product == null)
//        throw new InvalidOperationException("Product not found.");

//    // Recalculate current stock
//    product.RecalculateStock();

//    if (line.Quantity > product.AvailableStock)
//        throw new InvalidOperationException("Insufficient stock available for reservation.");

//    // Add reservation stock action
//    var reservation = new StockAction
//    {
//        ProductId = product.Id,
//        Quantity = line.Quantity,
//        Type = StockActionType.Reservation
//    };

//    _context.StockActions.Add(reservation);

//    // Add order line
//    _context.OrderLines.Add(line);
//    product.RecalculateStock();

//    await _context.SaveChangesAsync();
//}





public async Task UpdateAsync(OrderLine updatedLine)
{
    //var existingLine = await _context.OrderLines.Include(ol => ol.Product).Include(ol => ol.Order).FirstOrDefaultAsync(ol => ol.Id == id);

    var existingLine = await _context.OrderLines.Include(ol => ol.Product).Include(ol => ol.Order).AsNoTracking().FirstOrDefaultAsync(ol => ol.Id == updatedLine.Id);

    Console.WriteLine($"Updating OrderLine ID: {updatedLine.Id}, Product ID: {updatedLine.ProductId}, Quantity: {updatedLine.Quantity}");
    Console.WriteLine($"Existing OrderLine ID: {existingLine?.Id}, Product ID: {existingLine?.ProductId}, Quantity: {existingLine?.Quantity}");

    if (existingLine == null) throw new InvalidOperationException("Order line not found.");
    if (existingLine.Order.Status != OrderStatus.Created) throw new InvalidOperationException("Only 'Created' orders can be modified.");

    //nog toevoegen zelfde product.

    //Check if something changed
    if (existingLine.ProductId != updatedLine.ProductId)
    {
        var oldProduct = await _context.Products.Include(p => p.StockActions).FirstOrDefaultAsync(p => p.Id == existingLine.ProductId);
        Console.WriteLine($"Reverting reservation for old product ID: {oldProduct?.Id}, Available: {oldProduct.AvailableStock}");

        // Apply reservation to new product
        var newProduct = await _context.Products.Include(p => p.StockActions).FirstOrDefaultAsync(p => p.Id == updatedLine.ProductId);

        if (updatedLine.Quantity > newProduct.AvailableStock) throw new InvalidOperationException("Insufficient stock in new product.");

        var reservation = new StockAction { ProductId = newProduct.Id, Quantity = updatedLine.Quantity, Type = StockActionType.Reservation, OrderLineId = existingLine.Id };
        var undoAction = new StockAction { ProductId = oldProduct.Id, Quantity = -existingLine.Quantity, Type = StockActionType.Reservation, OrderLineId = existingLine.Id };

        _context.StockActions.Add(reservation);
        _context.StockActions.Add(undoAction);
        oldProduct.RecalculateStock();
        newProduct.RecalculateStock();
        // Update OrderLine fields
        await _context.SaveChangesAsync();
    }
    else if (existingLine.Quantity != updatedLine.Quantity)
    {
        throw new NotImplementedException("Update orderline zelfde product nog implementeren");
        await _context.SaveChangesAsync();
    }
}

*/
