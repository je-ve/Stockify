using Microsoft.AspNetCore.Mvc;
using Stockify.Logic;
using Stockify.Objects;
using Stockify.API.Dto;
namespace Stockify.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OrderController : ControllerBase
{
    private readonly IOrderService _orderService;

    public OrderController(IOrderService _service)
    {
        _orderService = _service;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var orders = await _orderService.GetAllAsync();
        return Ok(orders);
    }  
    
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        var order = await _orderService.GetByIdAsync(id);
        if (order == null) return NotFound("Order not found");
        return Ok(order);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    // POST http://localhost:5008/api/order

    public async Task<IActionResult> Create([FromBody] CreateOrderDto order)
    {
        if (order == null || order.Lines == null || order.Lines.Count == 0)
        {
            return BadRequest("Invalid order data.");
        }
        try
        {
            var orderToCreate = new Order
            {
                CustomerId = order.customerId
            };

            foreach (var line in order.Lines)
            {
                orderToCreate.OrderLines.Add(new OrderLine { ProductId = line.ProductId, Quantity = line.Quantity });
            }

            await _orderService.AddAsync(orderToCreate, "068a5f94-7b85-4831-9d74-b2bf62d460e1");
            return StatusCode(StatusCodes.Status201Created, new { Message = "Order created" });
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new
            {


                message = "An error occurred while processing your request.",
                error = ex.Message,
                inner = ex.InnerException?.Message ?? ex.Message
        });
        }
    }
   

   
    //Enkel header aanpassen

    [HttpPatch("{id:int}")]    
    public async Task<IActionResult> UpdateHeader(int id, [FromBody] int customerId)
    {

        var existingOrder = await _orderService.GetByIdAsync(id);
        if (existingOrder == null)
        {
            return NotFound("Order not found.");
        }

        try
        {
            existingOrder.CustomerId = customerId;
            await _orderService.UpdateAsync(existingOrder, "068a5f94-7b85-4831-9d74-b2bf62d460e1");
            return Ok(new { Message = "Order updated successfully." });
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new
            {
                message = "An error occurred while updating the order.",
                error = ex.Message
            });
        }
    }    
}
