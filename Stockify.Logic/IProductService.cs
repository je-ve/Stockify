
using Stockify.Objects;
namespace Stockify.Logic;
public interface IProductService
{
    Task<List<Product>> GetAllAsync();
    Task<Product?> GetByIdAsync(int id);
    Task AddAsync(Product product);
    Task UpdateAsync(Product product);
    Task DeleteAsync(int id);
    Task<PaginatedResult<Product>> GetPagedAsync(int pageNumber, int pageSize, string sortBy, bool ascending);
    public Task RecalculateStock(Product product);
    public Task RecalculateStock(int id);
}
