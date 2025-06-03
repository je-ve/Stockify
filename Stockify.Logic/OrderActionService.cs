// Interface
using Microsoft.EntityFrameworkCore;
using Stockify.Data;
using Stockify.Objects;

namespace Stockify.Logic;

public class OrderActionService : IOrderActionService
{
    private readonly StockifyContext _context;
    public OrderActionService(StockifyContext context) => _context = context;

    public async Task<List<OrderAction>> GetAllAsync() => await _context.OrderActions
        .Include(oa => oa.Order)
        .ToListAsync();

    public async Task<OrderAction?> GetByIdAsync(int id) => await _context.OrderActions
        .Include(oa => oa.Order)
        .FirstOrDefaultAsync(oa => oa.Id == id);

    public async Task AddAsync(OrderAction action)
    {
        _context.OrderActions.Add(action);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var action = await _context.OrderActions.FindAsync(id);
        if (action != null)
        {
            _context.OrderActions.Remove(action);
            await _context.SaveChangesAsync();
        }
    }
}
