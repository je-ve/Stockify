using Stockify.Objects;
namespace Stockify.Logic;
public interface IOrderActionService
{
    Task<List<OrderAction>> GetAllAsync();
    Task<OrderAction?> GetByIdAsync(int id);
    Task AddAsync(OrderAction action);
    Task DeleteAsync(int id);
}
