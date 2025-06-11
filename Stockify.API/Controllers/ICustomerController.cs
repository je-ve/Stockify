using Microsoft.AspNetCore.Mvc;
using Stockify.API.Dto;
namespace Stockify.API.Controllers;
public interface ICustomerController
{
   
    Task<IActionResult> Get(); 
    Task<IActionResult> GetById(int id); 
   
    Task<IActionResult> UpdateName(int id, [FromBody] string name);
    Task<IActionResult> UpdateEmail(int id, [FromBody] string email);
    Task<IActionResult> Delete(int id); 
}
