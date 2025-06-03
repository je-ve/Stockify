using Microsoft.AspNetCore.Mvc;
using Stockify.API.Dto;
namespace Stockify.API.Controllers;
public interface ICustomerController
{
   // Task<IActionResult> Create([FromBody] CustomerDto customer);    // Creates a new customer
    Task<IActionResult> Get(); // Retrieves all customers
    Task<IActionResult> GetById(int id); // Retrieves a customer by its ID
   // Task<IActionResult> UpdateCustomer(int id, [FromBody] CustomerDto updatedCustomer); // Updates a customer by its ID
    Task<IActionResult> UpdateName(int id, [FromBody] string name); // Updates the name of a customer by its ID
    Task<IActionResult> UpdateEmail(int id, [FromBody] string email); // Updates the email of a customer by its ID
    Task<IActionResult> Delete(int id); // Deletes a customer by its ID
}
