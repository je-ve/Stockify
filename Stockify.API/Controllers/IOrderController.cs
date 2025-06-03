using Microsoft.AspNetCore.Mvc;
using Stockify.API.Dto;
namespace Stockify.API.Controllers;
public interface IOrderController
{
 //   public Task<IActionResult> Create([FromBody] OrderDto order); // Creates a new order
    public Task<IActionResult> Get(); // Retrieves all orders
    public Task<IActionResult> GetById(int id); // Retrieves an order by its ID
   // public Task<IActionResult> UpdateOrder(int id, [FromBody] OrderDto updatedOrder); // Updates an order by its ID
    public Task<IActionResult> UpdateStatus(int id, [FromBody] string status); // Updates the status of an order by its ID
    public Task<IActionResult> Delete(int id); // Deletes an order by its ID
    public Task<IActionResult> GetByCustomerId(int customerId); // Retrieves orders by customer ID
    public Task<IActionResult> GetByProductId(int productId); // Retrieves orders by product ID
    public Task<IActionResult> GetPaged(int pageNumber, int pageSize, string sortBy, bool ascending); // Retrieves paginated orders
    public Task<IActionResult> GetByStatus(string status); // Retrieves orders by status
    //public Task<IActionResult> GetByDateRange(DateTime startDate, DateTime endDate); // Retrieves orders within a date range
    //public Task<IActionResult> GetByCustomerIdPaged(int customerId, int pageNumber, int pageSize, string sortBy, bool ascending); // Retrieves paginated orders by customer ID
    //ublic Task<IActionResult> GetByProductIdPaged(int productId, int pageNumber, int pageSize, string sortBy, bool ascending); // Retrieves paginated orders by product ID
    //public Task<IActionResult> GetByStatusPaged(string status, int pageNumber, int pageSize, string sortBy, bool ascending); // Retrieves paginated orders by status
    //public Task<IActionResult> GetByDateRangePaged(DateTime startDate, DateTime endDate, int pageNumber, int pageSize, string sortBy, bool ascending); // Retrieves paginated orders within a date range

}
