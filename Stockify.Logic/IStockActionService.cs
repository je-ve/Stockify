using Stockify.Objects;
namespace Stockify.Logic;
public interface IStockActionService
{
    Task AddAsync(StockAction action);
    Task AddReservation(OrderLine orderLine);
    Task AddReservations(List<OrderLine> orderLines);
    Task DeleteAsync(int id);
    Task DeleteReservation(OrderLine orderLine);
    Task DeleteReservations(List<OrderLine> orderLines);
    Task<List<StockAction>> GetAllAsync();
    Task<StockAction?> GetByIdAsync(int id);
    Task<StockAction?> GetByOrderLineIdAsync(int id);
    Task<PaginatedResult<StockAction>> GetPagedAsync(int productId, int pageNumber, int pageSize, string sortBy, bool ascending);
    Task UpdateReservation(OrderLine orderLine);
    Task UpdateReservations(List<OrderLine> orderLines);
    Task UpdateReservations(Order order);
}
