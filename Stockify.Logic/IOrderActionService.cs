using Stockify.Objects;
namespace Stockify.Logic;
public interface IOrderActionService
{

    public Task CreateOrderAction(int orderId, OrderActionType type, string? userId = null);
    /*
    Task<List<OrderAction>> GetAllAsync();
    Task<OrderAction?> GetByIdAsync(int id);
    Task AddAsync(OrderAction action);
    Task DeleteAsync(int id);
    */
}
