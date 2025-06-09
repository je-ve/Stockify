using Stockify.Objects;
namespace Stockify.Logic;
public interface IOrderService
{
    Task<List<Order>> GetAllAsync();
    Task<Order?> GetByIdAsync(int id);
    Task<Order> AddAsync(Order order, string currentUserId);
    Task<Order?> GetByIdAsyncAsNoTracking(int id);    
    Task UpdateAsync(Order order, string currentUserId);
  //  Task UpdateAsyncUntracked(Order order);
    Task DeleteAsync(int id);
    Task<PaginatedResult<Order>> GetPagedAsync(int pageNumber, int pageSize, string sortBy, bool ascending);
}
