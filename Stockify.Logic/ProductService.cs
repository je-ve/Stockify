using Microsoft.EntityFrameworkCore;
using Stockify.Data;
using Stockify.Objects;

namespace Stockify.Logic;

/// <summary>
/// Serviceklasse voor het beheren van producten en voorraad in Stockify.
/// </summary>
public class ProductService : IProductService
{
    private readonly StockifyContext _context;

    /// <summary>
    /// Constructor voor ProductService.
    /// </summary>
    /// <param name="context">De databasecontext.</param>
    public ProductService(StockifyContext context) => _context = context;

    /// <summary>
    /// Haalt alle producten op, optioneel alleen actieve.
    /// </summary>
    /// <param name="onlyActive">True om enkel actieve producten op te halen.</param>
    /// <returns>Lijst van producten.</returns>
    public async Task<List<Product>> GetAllAsync(bool onlyActive = true)
    {
        if (onlyActive)
        {
            return await _context.Products
              .Where(c => c.IsActive)
              .Include(c => c.CreatedBy)
              .Include(c => c.UpdatedBy)
              .ToListAsync();
        }
        return await _context.Products.ToListAsync();
    }

    /// <summary>
    /// Haalt een product op op basis van zijn ID.
    /// </summary>
    /// <param name="id">De ID van het product.</param>
    /// <returns>Het gevonden product of null.</returns>
    public async Task<Product?> GetByIdAsync(int id) => await _context.Products.FindAsync(id);

    /// <summary>
    /// Voegt een nieuw product toe aan de database.
    /// </summary>
    /// <param name="product">Het toe te voegen product.</param>
    /// <param name="currentUserId">ID van de gebruiker die de actie uitvoert.</param>
    public async Task AddAsync(Product product, string currentUserId)
    {
        product.CreatedAt = DateTime.UtcNow;
        product.CreatedById = currentUserId;
        product.UpdatedAt = DateTime.UtcNow;
        product.UpdatedById = currentUserId;
        _context.Products.Add(product);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Werkt een bestaand product bij.
    /// </summary>
    /// <param name="product">Het bij te werken product.</param>
    /// <param name="currentUserId">ID van de gebruiker die de actie uitvoert.</param>
    public async Task UpdateAsync(Product product, string currentUserId)
    {
        product.UpdatedAt = DateTime.UtcNow;
        product.UpdatedById = currentUserId;
        _context.Products.Update(product);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Verwijdert een product op basis van ID.
    /// </summary>
    /// <param name="id">De ID van het te verwijderen product.</param>
    public async Task DeleteAsync(int id)
    {
        var product = await _context.Products.FindAsync(id);
        if (product != null)
        {
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
        }
    }

    /// <summary>
    /// Zet een product inactief indien er geen voorraad is.
    /// </summary>
    /// <param name="id">De ID van het product.</param>
    /// <param name="currentUserId">De gebruiker die de actie uitvoert.</param>
    public async Task SetInactiveAsync(int id, string currentUserId)
    {
        var product = await _context.Products.FindAsync(id);

        if (product.TotalStock > 0)
        {
            throw new Exception("Enkel producten zonder voorraad kunnen verwijderd worden");
        }

        if (product != null)
        {
            product.IsActive = false;
            product.UpdatedAt = DateTime.UtcNow;
            product.UpdatedById = currentUserId;
            _context.Products.Update(product);
            await _context.SaveChangesAsync();
        }
    }

    /// <summary>
    /// Herberekent de voorraad van een product.
    /// </summary>
    /// <param name="product">Het product waarvoor de voorraad herberekend moet worden.</param>
    public async Task RecalculateStock(Product product)
    {
        _context.Attach(product);
        List<StockAction> actions = _context.StockActions.Where(sa => sa.ProductId == product.Id).ToList();
        int TotalStock = actions.Sum(a => (int)a.Type * a.Quantity);
        int ReservedStock = actions.Where(a => a.Type == StockActionType.Reservation).Sum(a => a.Quantity);
        product.AvailableStock = TotalStock - ReservedStock;
        product.TotalStockActions = actions.Count;
        product.TotalStock = TotalStock;
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Herberekent de voorraad op basis van product ID.
    /// </summary>
    /// <param name="id">Het ID van het product.</param>
    public async Task RecalculateStock(int id)
    {
        var product = _context.Products.FirstOrDefault(p => p.Id == id);
        if (product == null) throw new Exception($"Product met ID {id} niet gevonden.");
        await RecalculateStock(product);
    }

    /// <summary>
    /// Haalt een pagina met producten op met sortering en filtering.
    /// </summary>
    /// <param name="pageNumber">Het paginanummer (1-based).</param>
    /// <param name="pageSize">Aantal items per pagina.</param>
    /// <param name="sortBy">Kolom waarop gesorteerd wordt.</param>
    /// <param name="ascending">True voor oplopende sortering.</param>
    /// <param name="onlyActive">True om alleen actieve producten op te halen.</param>
    /// <returns>Een paginatie-resultaat van producten.</returns>
    public async Task<PaginatedResult<Product>> GetPagedAsync(int pageNumber, int pageSize, string sortBy, bool ascending, bool onlyActive = true)
    {
        var query = _context.Products.Include(c => c.UpdatedBy).Include(c => c.CreatedBy).AsQueryable();

        if (onlyActive)
        {
            query = query.Where(c => c.IsActive);
        }

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
            ("laststockaction", true) => query.OrderBy(c => c.LastStockAction),
            ("laststockaction", false) => query.OrderByDescending(c => c.LastStockAction),
            ("createdby", true) => query.OrderBy(c => c.CreatedBy.UserName),
            ("createdby", false) => query.OrderByDescending(c => c.CreatedBy.UserName),
            ("createdat", true) => query.OrderBy(c => c.CreatedAt),
            ("createdat", false) => query.OrderByDescending(c => c.CreatedAt),
            ("updatedby", true) => query.OrderBy(c => c.UpdatedBy.UserName),
            ("updatedby", false) => query.OrderByDescending(c => c.UpdatedBy.UserName),
            ("updatedat", true) => query.OrderBy(c => c.UpdatedAt),
            ("updatedat", false) => query.OrderByDescending(c => c.UpdatedAt),
            _ => query.OrderBy(c => c.Name)
        };

        var totalCount = await query.CountAsync();
        var items = await query.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();

        return new PaginatedResult<Product> { Items = items, TotalCount = totalCount };
    }

    /// <summary>
    /// Haalt de top 10 producten op op basis van aantal verkochte items.
    /// </summary>
    /// <returns>Lijst van tuples (productnaam, totaal aantal).</returns>
    public async Task<List<(string ProductName, int TotalQuantity)>> GetTopProductsAsync()
    {
        return await _context.StockActions
            .Where(sa => sa.OrderLineId != null)
            .GroupBy(sa => sa.ProductId)
            .Select(g => new
            {
                ProductId = g.Key,
                TotalQuantity = g.Sum(sa => sa.Quantity)
            })
            .OrderByDescending(x => x.TotalQuantity)
            .Take(10)
            .Join(_context.Products,
                  sa => sa.ProductId,
                  p => p.Id,
                  (sa, p) => new { p.Name, sa.TotalQuantity })
            .Select(x => new ValueTuple<string, int>(x.Name, x.TotalQuantity))
            .ToListAsync();
    }
}



/*

using Microsoft.EntityFrameworkCore;
using Stockify.Data;
using Stockify.Objects;
namespace Stockify.Logic;

public class ProductService : IProductService
{
    private readonly StockifyContext _context;
    public ProductService(StockifyContext context) => _context = context;
    public async Task<List<Product>> GetAllAsync(bool onlyActive = true)
    {
        if (onlyActive)
        {
            return await _context.Products
            .Where(c => c.IsActive)
              .Include(c => c.CreatedBy)
              .Include(c => c.UpdatedBy)
              .ToListAsync();
        }
        return await _context.Products.ToListAsync();
    }

    public async Task<Product?> GetByIdAsync(int id) => await _context.Products.FindAsync(id);
    public async Task AddAsync(Product product, string currentUserId)
    {
        product.CreatedAt = DateTime.UtcNow;
        product.CreatedById = currentUserId;
        product.UpdatedAt = DateTime.UtcNow;
        product.UpdatedById = currentUserId;
        _context.Products.Add(product);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Product product, string currentUserId)
    {
        product.UpdatedAt = DateTime.UtcNow;
        product.UpdatedById = currentUserId;

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

    public async Task SetInactiveAsync(int id, string currentUserId)
    {
        var product = await _context.Products.FindAsync(id);

        if(product.TotalStock > 0)
        {
            throw new Exception("Enkel producten zonder voorraad kunnen verwijderd worden");
        }

        if (product != null)
        {
            product.IsActive = false; // Soft delete
            product.UpdatedAt = DateTime.UtcNow;
            product.UpdatedById = currentUserId;

            _context.Products.Update(product);
            await _context.SaveChangesAsync();
        }
    }

    public async Task RecalculateStock(Product product)
    {
        _context.Attach(product);
        List<StockAction> actions = _context.StockActions.Where(sa => sa.ProductId == product.Id).ToList();
        int TotalStock = actions.Sum(a => (int)a.Type * a.Quantity);
        int ReservedStock = actions.Where(a => a.Type == StockActionType.Reservation).Sum(a => a.Quantity);
        product.AvailableStock = TotalStock - ReservedStock;
        product.TotalStockActions = actions.Count;
        product.TotalStock = TotalStock;
        //product.LastStockAction = actions.Count == 0 ? actions.Max(a => a.CreatedAt) : null;
        await _context.SaveChangesAsync();
    }

    public async Task RecalculateStock(int id)
    {
        var product = _context.Products.FirstOrDefault(p => p.Id == id);
        if (product == null) throw new Exception($"Product with ID {id} not found. Can not calculate stock on null");
        await RecalculateStock(product);
    }

    public async Task<PaginatedResult<Product>> GetPagedAsync(int pageNumber, int pageSize, string sortBy, bool ascending, bool onlyActive = true)
    {
        var query = _context.Products.Include(c => c.UpdatedBy).Include(c => c.CreatedBy).AsQueryable();

        if (onlyActive)
        {
            query = query.Where(c => c.IsActive); // assuming "Active" is a bool property
        }

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
            ("laststockaction", true) => query.OrderBy(c => c.LastStockAction),
            ("laststockaction", false) => query.OrderByDescending(c => c.LastStockAction),
            ("createdby", true) => query.OrderBy(c => c.CreatedBy.UserName),
            ("createdby", false) => query.OrderByDescending(c => c.CreatedBy.UserName),
            ("createdat", true) => query.OrderBy(c => c.CreatedAt),
            ("createdat", false) => query.OrderByDescending(c => c.CreatedAt),
            ("updatedby", true) => query.OrderBy(c => c.UpdatedBy.UserName),
            ("updatedby", false) => query.OrderByDescending(c => c.UpdatedBy.UserName),
            ("updatedat", true) => query.OrderBy(c => c.UpdatedAt),
            ("updatedat", false) => query.OrderByDescending(c => c.UpdatedAt),
            _ => query.OrderBy(c => c.Name) // default
        };

        var totalCount = await query.CountAsync();
        var items = await query.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();

        return new PaginatedResult<Product> { Items = items, TotalCount = totalCount };
    }

    public async Task<List<(string ProductName, int TotalQuantity)>> GetTopProductsAsync()
    {
        return await _context.StockActions
            .Where(sa => sa.OrderLineId != null)
            .GroupBy(sa => sa.ProductId)
            .Select(g => new
            {
                ProductId = g.Key,
                TotalQuantity = g.Sum(sa => sa.Quantity)
            })
            .OrderByDescending(x => x.TotalQuantity)
            .Take(10)
            .Join(_context.Products,
                  sa => sa.ProductId,
                  p => p.Id,
                  (sa, p) => new { p.Name, sa.TotalQuantity })
            .Select(x => new ValueTuple<string, int>(x.Name, x.TotalQuantity))
            .ToListAsync();
    }
}

*/