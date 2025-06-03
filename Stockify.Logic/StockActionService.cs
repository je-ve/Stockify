// Interface
using System.Formats.Asn1;
using Microsoft.EntityFrameworkCore;
using Stockify.Data;
using Stockify.Objects;

namespace Stockify.Logic;

public class StockActionService : IStockActionService
{
    private readonly StockifyContext _context;
    private readonly IProductService productService;
    public StockActionService(StockifyContext context, IProductService productService)
    {
        _context = context;
        this.productService = productService;
    }

    public async Task<List<StockAction>> GetAllAsync() => await _context.StockActions.Include(sa => sa.Product).Include(sa => sa.OrderLine).ToListAsync();

    public async Task<StockAction?> GetByIdAsync(int id) => await _context.StockActions.Include(sa => sa.Product).Include(sa => sa.OrderLine).FirstOrDefaultAsync(sa => sa.Id == id);

    public async Task AddAsync(StockAction action)
    {
        _context.StockActions.Add(action);
        await _context.SaveChangesAsync();
        await productService.RecalculateStock(action.ProductId);
    }

    public async Task DeleteAsync(int id)
    {
        var action = await _context.StockActions.FindAsync(id);
        if (action != null)
        {
            _context.StockActions.Remove(action);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<PaginatedResult<StockAction>> GetPagedAsync(int productId, int pageNumber, int pageSize, string sortBy, bool ascending)
    {
        var query = _context.StockActions.Where(sa => sa.ProductId == productId);
        query = (sortBy.ToLower(), ascending) switch
        {
            ("type", true) => query.OrderBy(sa => sa.Type),
            ("type", false) => query.OrderByDescending(sa => sa.Type),
            ("quantity", true) => query.OrderBy(sa => sa.Quantity),
            ("quantity", false) => query.OrderByDescending(sa => sa.Quantity),
            ("createdat", true) => query.OrderBy(sa => sa.CreatedAt),
            ("createdat", false) => query.OrderByDescending(sa => sa.CreatedAt),
            _ => query.OrderByDescending(sa => sa.CreatedAt)
        };

        var totalCount = await query.CountAsync();

        var items = await query
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        return new PaginatedResult<StockAction>
        {
            Items = items,
            TotalCount = totalCount
        };
    }

    public async Task AddReservation(OrderLine orderLine)
    {
        var product = await _context.Products.Include(p => p.StockActions).FirstOrDefaultAsync(p => p.Id == orderLine.ProductId);
        var action = new StockAction
        {
            ProductId = orderLine.ProductId,
            Type = StockActionType.Reservation,
            Quantity = orderLine.Quantity,
            OrderLineId = orderLine.Id
        };

        _context.StockActions.Add(action);
        await _context.SaveChangesAsync();
        await productService.RecalculateStock(action.ProductId);
    }

    public async Task AddReservations(List<OrderLine> orderLines)
    {
        foreach (var orderLine in orderLines)
        {
            await AddReservation(orderLine);
        }
    }

    //bestaande orderline, product en/of quantity aangepast
    public async Task UpdateReservation(OrderLine orderLine)
    {
        var action = await _context.StockActions.FirstOrDefaultAsync(sa => sa.OrderLineId == orderLine.Id && sa.Type == StockActionType.Reservation);
        if (action != null)
        {
            var oldProductId = action.ProductId; // Store old product ID for stock recalculation
            var newProductId = orderLine.ProductId;

            action.Quantity = orderLine.Quantity;// Update quantity ID if changed
            action.ProductId = orderLine.ProductId; // Update product ID if changed

            _context.StockActions.Update(action);

            await _context.SaveChangesAsync();
            await productService.RecalculateStock(oldProductId);
            await productService.RecalculateStock(newProductId);
        }
    }


    public async Task UpdateReservations(List<OrderLine> orderLines)
    {
        foreach (var orderLine in orderLines)
        {
            var action = await _context.StockActions.FirstOrDefaultAsync(sa => sa.OrderLineId == orderLine.Id && sa.Type == StockActionType.Reservation);
            if (action == null)
            {
                await AddReservation(orderLine);
            }
            else
            {
                await UpdateReservation(orderLine);
            }
        }
    }

    public async Task UpdateReservations(Order order)
    {

        // klopt dit, wat als alle orderlines verwijderd zijn? Kan niet in principe...
        if (order == null || order.OrderLines == null || !order.OrderLines.Any())
        {
            return; // No lines to update
        }
        await UpdateReservations(order.OrderLines.ToList()); // Update all order lines in the order
    }


    public async Task DeleteReservation(OrderLine orderLine)
    {
        var action = await _context.StockActions.FirstOrDefaultAsync(sa => sa.OrderLineId == orderLine.Id && sa.Type == StockActionType.Reservation);
        if (action != null)
        {
            _context.StockActions.Remove(action);
            await _context.SaveChangesAsync();
            await productService.RecalculateStock(action.ProductId);
        }
    }

    public async Task DeleteReservations(List<OrderLine> orderLines)
    {
        foreach (var orderLine in orderLines)
        {
            await DeleteReservation(orderLine);
        }
    }
}
