using Microsoft.EntityFrameworkCore;
using Stockify.Data;
using Stockify.Objects;
namespace Stockify.Logic;

public class ProductService : IProductService
{
    private readonly StockifyContext _context;
    public ProductService(StockifyContext context) => _context = context;
    public async Task<List<Product>> GetAllAsync() => await _context.Products.ToListAsync();
    public async Task<Product?> GetByIdAsync(int id) => await _context.Products.FindAsync(id);

    public async Task AddAsync(Product product)
    {
        _context.Products.Add(product);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Product product)
    {
        _context.Products.Update(product);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var product = await _context.Products.FindAsync(id);
        if (product != null)
        {
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
        }
    }

    public async Task RecalculateStock(Product product)
    {
        _context.Attach(product);
        List<StockAction> actions = _context.StockActions.Where(sa=>sa.ProductId == product.Id).ToList();
        int TotalStock = actions.Sum(a => (int)a.Type * a.Quantity);
        int ReservedStock = actions.Where(a => a.Type == StockActionType.Reservation).Sum(a => a.Quantity);
        product.AvailableStock = TotalStock - ReservedStock;
        product.TotalStockActions = actions.Count;
        product.TotalStock = TotalStock;
        product.LastStockAction = actions.Count == 0 ? actions.Max(a => a.CreatedAt) : null;
        await _context.SaveChangesAsync();
    }

    public async Task RecalculateStock(int id)
    {
        var product = _context.Products.FirstOrDefault(p => p.Id == id);
        if (product == null) throw new Exception($"Product with ID {id} not found. Can not calculate stock on null");
        await RecalculateStock(product);
    }

    public async Task<PaginatedResult<Product>> GetPagedAsync(int pageNumber, int pageSize, string sortBy, bool ascending)
    {
        var query = _context.Products.AsQueryable();

        // Apply sorting
        query = (sortBy.ToLower(), ascending) switch
        {
            ("name", true) => query.OrderBy(c => c.Name),
            ("name", false) => query.OrderByDescending(c => c.Name),
            ("serialnumber", true) => query.OrderBy(c => c.SerialNumber),
            ("serialnumber", false) => query.OrderByDescending(c => c.SerialNumber),
            ("totalstock", true) => query.OrderBy(c => c.TotalStock),
            ("totalstock", false) => query.OrderByDescending(c => c.TotalStock),
            ("availablestock", true) => query.OrderBy(c => c.AvailableStock),
            ("availablestock", false) => query.OrderByDescending(c => c.AvailableStock),
            ("totalstockactions", true) => query.OrderBy(c => c.TotalStockActions),
            ("totalstockactions", false) => query.OrderByDescending(c => c.TotalStockActions),
            ("laststockaction", true) => query.OrderBy(c => c.TotalStockActions),
            ("laststockaction", false) => query.OrderByDescending(c => c.TotalStockActions),
            _ => query.OrderBy(c => c.Name) // default
        };

        var totalCount = await query.CountAsync();
        var items = await query.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();

        return new PaginatedResult<Product> { Items = items, TotalCount = totalCount };
    }
}
