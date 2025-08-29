using Microsoft.AspNetCore.Mvc;
using Stockify.Logic;
using Stockify.Objects;
using Stockify.API.Dto;
using Stockify.Logic.Services;
using Microsoft.AspNetCore.Authorization;
namespace Stockify.API.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class customerController : ControllerBase
{
    private readonly ICustomerService _customerService;
    public customerController(ICustomerService customerService)
    {
        _customerService = customerService;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var customers = await _customerService.GetAllAsync();
        return Ok(customers);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        var customer = await _customerService.GetByIdAsync(id);
        if (customer == null) return NotFound("customer not found");
        return Ok(customer);
    }



    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    // POST http://localhost:5008/api/customer/    
    public async Task<IActionResult> Create([FromBody] CreateCustomerDto customer)
    {
        var customerToCreate = new Customer
        {
            Name = customer.Name,
            Street = customer.Street,
            City = customer.City,
            ZipCode = customer.ZipCode
        };
        await _customerService.AddAsync(customerToCreate, "068a5f94-7b85-4831-9d74-b2bf62d460e1");
        return StatusCode(StatusCodes.Status201Created, new { Message = "customer created" });
    }

    [HttpPatch("{id:int}")]
    // PATCH http://localhost:5008/api/customer/id    
    public async Task<IActionResult> UpdateCustomer(int id, [FromBody] CreateCustomerDto updatedcustomer)
    {
        var customer = await _customerService.GetByIdAsync(id);

        if (customer == null)
        {
            return StatusCode(StatusCodes.Status500InternalServerError);
        }

        customer.Name = updatedcustomer.Name;
        customer.Street = updatedcustomer.Street;
        customer.City = updatedcustomer.City;
        customer.ZipCode = updatedcustomer.ZipCode;
        await _customerService.UpdateAsync(customer, "068a5f94-7b85-4831-9d74-b2bf62d460e1");
        return Ok(new { Message = "Customer updated" });
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var customer = await _customerService.GetByIdAsync(id);
        if (customer == null) return NotFound("Customer not found");
        await _customerService.DeleteAsync(id);
        return Ok(new { Message = "Customer deleted" });
    }
}
