using Microsoft.EntityFrameworkCore;
using Stockify.Data;
using Stockify.Objects;

namespace Stockify.Logic;

/// <summary>
/// Service to manage Order entities including creation, retrieval, update, delete, and pagination.
/// Handles related stock actions and interacts with Product and StockAction services.
/// </summary>
public class OrderService : IOrderService
{
    private readonly StockifyContext _context;
    private readonly IStockActionService stockActionService;
    private readonly IProductService productService;

    public OrderService(StockifyContext context, IStockActionService stockActionService, IProductService productService)
    {
        _context = context;
        this.stockActionService = stockActionService;
        this.productService = productService;
    }

    /// <summary>
    /// Retrieves all orders with related customers and order lines.
    /// </summary>
    public async Task<List<Order>> GetAllAsync() => await _context.Orders
        .Include(o => o.Customer)
        .Include(o => o.OrderLines)
        //.Include(o => o.Actions) // Uncomment if stock actions are needed
        .ToListAsync();

    /// <summary>
    /// Retrieves a single order by ID including related customer and order lines.
    /// </summary>
    public async Task<Order?> GetByIdAsync(int id) => await _context.Orders
        .Include(o => o.Customer)
        .Include(o => o.OrderLines)
        //.Include(o => o.Actions)
        .FirstOrDefaultAsync(o => o.Id == id);

    /// <summary>
    /// Retrieves a single order by ID as no-tracking (read-only).
    /// Includes order lines but not customer to optimize read performance.
    /// </summary>
    public async Task<Order?> GetByIdAsyncAsNoTracking(int id) => await _context.Orders
        .Include(o => o.OrderLines)
        .AsNoTracking()
        .FirstOrDefaultAsync(o => o.Id == id);

    /// <summary>
    /// Adds a new order with created/updated metadata and creates stock reservations.
    /// </summary>
    public async Task<Order> AddAsync(Order order, string currentUserId)
    {
        order.CreatedAt = DateTime.UtcNow;
        order.CreatedById = currentUserId;
        order.UpdatedAt = DateTime.UtcNow;
        order.UpdatedById = currentUserId;

        _context.Orders.Add(order);
        await _context.SaveChangesAsync();

        // Create stock reservations for the order lines
        await stockActionService.AddReservations(order.OrderLines.ToList());

        return order;
    }

    /// <summary>
    /// Updates an existing order and synchronizes stock reservations.
    /// </summary>
    public async Task UpdateAsync(Order order, string currentUserId)
    {
  
        order.UpdatedAt = DateTime.UtcNow;
        order.UpdatedById = currentUserId;

        _context.Orders.Update(order);
        await stockActionService.UpdateReservations(order);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Deletes an order, its related stock actions, and recalculates product stock.
    /// </summary>
    public async Task DeleteAsync(Order order)
    {
        // Remove related stock actions and recalculate stock
        foreach (var line in order.OrderLines.ToList())
        {
            var stockActions = await _context.StockActions
                .Where(sa => sa.OrderLineId == line.Id)
                .ToListAsync();

            foreach (var action in stockActions)
            {
                _context.StockActions.Remove(action);
                await productService.RecalculateStock(action.ProductId);
            }
        }

        await _context.SaveChangesAsync(); // Commit deletions before removing order lines

        // Remove order lines
        foreach (var line in order.OrderLines)
        {
            _context.OrderLines.Remove(line);
        }

        // Remove the order itself
        _context.Orders.Remove(order);

        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Deletes an order by ID.
    /// </summary>
    public async Task DeleteAsync(int id)
    {
        var order = await _context.Orders.FindAsync(id);
        if (order != null)
            await DeleteAsync(order);
    }

    /// <summary>
    /// Returns a paginated and sorted list of orders with related customer and user info.
    /// </summary>
    public async Task<PaginatedResult<Order>> GetPagedAsync(int pageNumber, int pageSize, string sortBy, bool ascending)
    {
        var query = _context.Orders
            .Include(o => o.Customer)
            .Include(c => c.UpdatedBy)
            .AsQueryable();

        // Apply dynamic sorting based on column name and direction
        query = (sortBy.ToLower(), ascending) switch
        {
            ("updatedat", false) => query.OrderByDescending(c => c.UpdatedAt),
            ("customernumber", true) => query.OrderBy(c => c.Customer.Id), // Adjust to Customer.Number if exists
            ("customernumber", false) => query.OrderByDescending(c => c.Customer.Id),
            ("customername", true) => query.OrderBy(c => c.Customer.Name),
            ("customername", false) => query.OrderByDescending(c => c.Customer.Name),
            ("createdby", true) => query.OrderBy(c => c.CreatedBy.UserName),
            ("createdby", false) => query.OrderByDescending(c => c.CreatedBy.UserName),
            ("createdat", true) => query.OrderBy(c => c.CreatedAt),
            ("createdat", false) => query.OrderByDescending(c => c.CreatedAt),
            ("updatedby", true) => query.OrderBy(c => c.UpdatedBy.UserName),
            ("updatedby", false) => query.OrderByDescending(c => c.UpdatedBy.UserName),
            ("updatedat", true) => query.OrderBy(c => c.UpdatedAt),
            _ => query.OrderByDescending(c => c.UpdatedAt) // Default sort
        };

        var totalCount = await query.CountAsync();

        // Retrieve the paginated list of orders
        var items = await query
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
using Microsoft.EntityFrameworkCore;
using Stockify.Data;
using Stockify.Objects;

namespace Stockify.Logic;

public class OrderService : IOrderService
{
    private readonly StockifyContext _context;
    private readonly IStockActionService stockActionService;
    private readonly IProductService productService;
    public OrderService(StockifyContext context, IStockActionService stockActionService, IProductService productService)
    {   
        _context = context;
        this.stockActionService = stockActionService;
        this.productService = productService;
    }

    public async Task<List<Order>> GetAllAsync() => await _context.Orders
        .Include(o => o.Customer)
        .Include(o => o.OrderLines)
      //  .Include(o => o.Actions)
        .ToListAsync();

    public async Task<Order?> GetByIdAsync(int id) => await _context.Orders.Include(o => o.Customer)
        .Include(o => o.OrderLines)
       // .Include(o => o.Actions)
        .FirstOrDefaultAsync(o => o.Id == id);

    public async Task<Order?> GetByIdAsyncAsNoTracking(int id) => await _context.Orders
    .Include(o => o.OrderLines)
    .AsNoTracking()
    .FirstOrDefaultAsync(o => o.Id == id);


    public async Task<Order> AddAsync(Order order, string currentUserId)
    {
        order.CreatedAt = DateTime.UtcNow;
        order.CreatedById = currentUserId;
        order.UpdatedAt = DateTime.UtcNow;
        order.UpdatedById = currentUserId;

        _context.Orders.Add(order);        
        await _context.SaveChangesAsync();
        await stockActionService.AddReservations(order.OrderLines.ToList());
        return order;
    }

    public async Task UpdateAsync(Order order, string currentUserId)
    {
      
order.UpdatedAt = DateTime.UtcNow;
        order.UpdatedById = currentUserId;

        _context.Orders.Update(order);
        await stockActionService.UpdateReservations(order);
        await _context.SaveChangesAsync();
    }
    
    public async Task DeleteAsync(Order order)
    {
        foreach (var line in order.OrderLines.ToList())
        {
            
            var stockActions = await _context.StockActions.Where(sa => sa.OrderLineId == line.Id).ToListAsync();

            foreach (var action in stockActions)
            {
                _context.StockActions.Remove(action);
                await productService.RecalculateStock(action.ProductId);
            }
        }
                
        await _context.SaveChangesAsync();
        
        foreach (var line in order.OrderLines)
        {
            _context.OrderLines.Remove(line);
        }        
        _context.Orders.Remove(order);
        await _context.SaveChangesAsync();

    }

    public async Task DeleteAsync(int id)
    {
        var order = await _context.Orders.FindAsync(id);
        if (order != null) await DeleteAsync(order);        
    }

    public async Task<PaginatedResult<Order>> GetPagedAsync(int pageNumber, int pageSize, string sortBy, bool ascending)
    {
        var query = _context.Orders.Include(o => o.Customer).Include(c => c.UpdatedBy).AsQueryable();

        // Apply sorting
        query = (sortBy.ToLower(), ascending) switch
        {
            ("updatedat", false) => query.OrderByDescending(c => c.UpdatedAt),
            ("customernumber", true) => query.OrderBy(c => c.Customer.Id),
            ("customernumber", false) => query.OrderByDescending(c => c.Customer.Id),
            ("customername", true) => query.OrderBy(c => c.Customer.Name),
            ("customername", false) => query.OrderByDescending(c => c.Customer.Name),
            ("createdby", true) => query.OrderBy(c => c.CreatedBy.UserName),
            ("createdby", false) => query.OrderByDescending(c => c.CreatedBy.UserName),
            ("createdat", true) => query.OrderBy(c => c.CreatedAt),
            ("createdat", false) => query.OrderByDescending(c => c.CreatedAt),
            ("updatedby", true) => query.OrderBy(c => c.UpdatedBy.UserName),
            ("updatedby", false) => query.OrderByDescending(c => c.UpdatedBy.UserName),
            ("updatedat", true) => query.OrderBy(c => c.UpdatedAt),            
            _ => query.OrderByDescending(c => c.UpdatedAt) // default
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

*/
