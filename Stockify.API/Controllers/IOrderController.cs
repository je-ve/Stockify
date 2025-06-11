using Microsoft.AspNetCore.Mvc;
using Stockify.API.Dto;
namespace Stockify.API.Controllers;
public interface IOrderController
{
    //   public Task<IActionResult> Create([FromBody] OrderDto order); // Creates a new order
    public Task<IActionResult> Get();
    public Task<IActionResult> GetById(int id);

    public Task<IActionResult> UpdateStatus(int id, [FromBody] string status);
    public Task<IActionResult> Delete(int id);
    public Task<IActionResult> GetByCustomerId(int customerId);
    public Task<IActionResult> GetByProductId(int productId);
    public Task<IActionResult> GetPaged(int pageNumber, int pageSize, string sortBy, bool ascending);
    public Task<IActionResult> GetByStatus(string status);


}
