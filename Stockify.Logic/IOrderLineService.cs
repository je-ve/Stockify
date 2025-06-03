using Stockify.Objects;
namespace Stockify.Logic;
public interface IOrderLineService
{
    Task<List<OrderLine>> GetAllAsync();
    Task<OrderLine?> GetByIdAsync(int id);
    Task AddAsync(OrderLine line);
    Task DeleteAsync(int id);
    Task UpdateAsync(int id);
    Task UpdateAsync(OrderLine orderLine);
}
