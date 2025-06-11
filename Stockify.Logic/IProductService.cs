
using Stockify.Objects;
namespace Stockify.Logic;
public interface IProductService
{
    Task<List<Product>> GetAllAsync(bool onlyActive = true);
    Task<Product?> GetByIdAsync(int id);
    Task AddAsync(Product product, string currentUserId);
    Task UpdateAsync(Product product, string currentUserId);
    Task DeleteAsync(int id);
    Task SetInactiveAsync(int id, string currentUserId);
    public Task<List<(string ProductName, int TotalQuantity)>> GetTopProductsAsync();
    Task<PaginatedResult<Product>> GetPagedAsync(int pageNumber, int pageSize, string sortBy, bool ascending, bool onlyActive = true);
    public Task RecalculateStock(Product product);
    public Task RecalculateStock(int id);
}
