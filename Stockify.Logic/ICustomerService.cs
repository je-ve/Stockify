using Stockify.Objects;
namespace Stockify.Logic.Services;
public interface ICustomerService
{
    Task AddAsync(Customer customer, string currentUserId);
    Task DeleteAsync(int id);
    Task<List<Customer>> GetAllAsync(bool onlyActive = true);
    Task<Customer?> GetByIdAsync(int id);
    Task UpdateAsync(Customer customer, string currentUserId);
    Task SetInactiveAsync(int id, string currentUserId);
    Task<PaginatedResult<Customer>> GetPagedAsync(int pageNumber, int pageSize, string sortBy, bool ascending, bool onlyActive = true);
    Task<List<(string CustomerName, int TotalQuantity)>> GetTopCustomersAsync();
}