using Stockify.Objects;
namespace Stockify.Logic.Services;
public interface ICustomerService
{
    Task AddAsync(Customer customer, string currentUserId);
    Task DeleteAsync(int id);
    Task<List<Customer>> GetAllAsync();
    Task<Customer?> GetByIdAsync(int id);
    Task UpdateAsync(Customer customer, string currentUserId);
    Task<PaginatedResult<Customer>> GetPagedAsync(int pageNumber, int pageSize, string sortBy, bool ascending);
    Task<List<(string CustomerName, int TotalQuantity)>> GetTopCustomersAsync();
}