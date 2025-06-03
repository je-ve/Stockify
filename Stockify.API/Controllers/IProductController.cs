using Microsoft.AspNetCore.Mvc;
using Stockify.API.Dto;
namespace Stockify.API.Controllers;
public interface IProductController
{
    Task<IActionResult> Create([FromBody] ProductDto product);   // Creates a new product
    Task<IActionResult> Get();  // Retrieves all products
    Task<IActionResult> GetById(int id); // Retrieves a product by its ID
    Task<IActionResult> UpdateProduct(int id, [FromBody] ProductDto updatedProduct); // Updates a product by its ID
    Task<IActionResult> UpdateName(int id, [FromBody] string name); // Updates the name of a product by its ID
    Task<IActionResult> UpdateSerialNumber(int id, [FromBody] long serialNumber); // Updates the serial number of a product by its ID
}