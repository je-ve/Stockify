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