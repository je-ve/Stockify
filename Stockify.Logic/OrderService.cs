// Interface
using Microsoft.EntityFrameworkCore;
using Stockify.Data;
using Stockify.Objects;

namespace Stockify.Logic;

public class OrderService : IOrderService
{
    private readonly StockifyContext _context;
    private readonly IStockActionService stockActionService;
    public OrderService(StockifyContext context, IStockActionService stockActionService)
    {
        _context = context;
        this.stockActionService = stockActionService;
    }

    public async Task<List<Order>> GetAllAsync() => await _context.Orders
        .Include(o => o.Customer)
        .Include(o => o.OrderLines)
        .Include(o => o.Actions)
        .ToListAsync();

    public async Task<Order?> GetByIdAsync(int id) => await _context.Orders.Include(o => o.Customer)
        .Include(o => o.OrderLines)
        .Include(o => o.Actions)
        .FirstOrDefaultAsync(o => o.Id == id);

    public async Task<Order?> GetByIdAsyncAsNoTracking(int id) => await _context.Orders
    .Include(o => o.OrderLines)
    .AsNoTracking()
    .FirstOrDefaultAsync(o => o.Id == id);


    public async Task<Order> AddAsync(Order order)
    {
        _context.Orders.Add(order);        
        await _context.SaveChangesAsync();
        await stockActionService.AddReservations(order.OrderLines.ToList());
        return order;
    }

    public async Task UpdateAsync(Order order)
    {
        if (order.Status != OrderStatus.Created)
        {
            throw new InvalidOperationException("Enkel nieuwe bestellingen kunnen aangepast worden.");
        }
        _context.Orders.Update(order);
        await stockActionService.UpdateReservations(order);
        await _context.SaveChangesAsync();
    }


    //TODO//
    public async Task DeleteAsync(Order order)
    {
        if (order.Status != OrderStatus.Created)
        {
            throw new InvalidOperationException("Enkel nieuwe bestellingen kunnen verwijderd worden.");
        }
        _context.Orders.Remove(order);
        await stockActionService.DeleteReservations(order.OrderLines.ToList());
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var order = await _context.Orders.FindAsync(id);
        if (order != null) await DeleteAsync(order);        
    }

    public async Task<PaginatedResult<Order>> GetPagedAsync(int pageNumber, int pageSize, string sortBy, bool ascending)
    {
        var query = _context.Orders.Include(o => o.Customer).AsQueryable();

        // Apply sorting
        query = (sortBy.ToLower(), ascending) switch
        {
            ("customernumber", true) => query.OrderBy(c => c.Customer.Id),
            ("customernumber", false) => query.OrderByDescending(c => c.Customer.Id),
            ("customername", true) => query.OrderBy(c => c.Customer.Name),
            ("customername", false) => query.OrderByDescending(c => c.Customer.Name),
            _ => query.OrderBy(c => c.Id) // default
        };

        var totalCount = await query.CountAsync();

        var items = await query.Include(o => o.Customer)
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        return new PaginatedResult<Order>
        {
            Items = items,
            TotalCount = totalCount
        };
    }
}


/*
    
    public async Task UpdateAsyncUntracked(Order order)
    {
        //todo totaal bestelde hoeveelheid van alle producten voor en na vergelijken en stockreservaties aanpassen
        // Detach all previously tracked entities (if any) (ipv pagina te herladen)
        var changedEntries = _context.ChangeTracker.Entries().ToList();
        foreach (var entry in changedEntries)
            entry.State = EntityState.Detached;


        // Attach the main order entity
        _context.Attach(order);
        _context.Entry(order).State = EntityState.Modified;

        // Get all existing order lines from the DB
        var existingLines = await _context.OrderLines
            .Where(ol => ol.OrderId == order.Id)
            .ToListAsync();

        // Remove order lines that are no longer in the updated list
        foreach (var existing in existingLines)
        {
            if (!order.OrderLines.Any(l => l.Id == existing.Id))
            {
                _context.OrderLines.Remove(existing);
            }
        }

        // Add or update current order lines
        foreach (var line in order.OrderLines)
        {
            if (line.Id == 0)
            {
                // Ensure FK is set for new lines
                line.OrderId = order.Id;
                _context.Entry(line).State = EntityState.Added;
            }
            else
            {
                _context.Entry(line).State = EntityState.Modified;
            }
        }

        await _context.SaveChangesAsync();
    }
    */
