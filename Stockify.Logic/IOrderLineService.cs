using Stockify.Objects;
namespace Stockify.Logic;
public interface IOrderLineService
{
    Task<List<OrderLine>> GetAllAsync();
    Task<OrderLine?> GetByIdAsync(int id);
    Task AddAsync(OrderLine line, string currentUserId);
    Task DeleteAsync(int id);
    Task UpdateAsync(int id, string currentUserId);
    Task UpdateAsync(OrderLine orderLine, string currentUserId);
}
