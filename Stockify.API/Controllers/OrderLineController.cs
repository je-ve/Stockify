using Microsoft.AspNetCore.Mvc;
using Stockify.Logic;
using Stockify.Objects;
using Stockify.API.Dto;
namespace Stockify.API.Controllers;

/*

[Route("api/[controller]")]
[ApiController]
public class OrderLineController : ControllerBase
{
    private readonly IOrderLineService _orderLineService;
    private readonly IOrderService _orderService;
    public OrderLineController(IOrderLineService orderLineService, IOrderService orderService)
    {
        _orderLineService = orderLineService;
        _orderService = orderService;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var lines = await _orderLineService.GetAllAsync();
        return Ok(lines);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        var line = await _orderLineService.GetByIdAsync(id);
        if (line == null) return NotFound("Line not found");
        return Ok(line);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    // POST http://localhost:5008/api/orderline/
    public async Task<IActionResult> Create([FromBody] OrderLineWithOrderIdDto orderLine)
    {
        if (orderLine == null)
        {
            return BadRequest("Invalid order line data.");
        }

        // Check if the order exists
        var order = await _orderService.GetByIdAsync(orderLine.OrderId);
        if (order == null)
        {
            return NotFound($"Order with ID {orderLine.OrderId} not found.");
        }
        var lineToCreate = new OrderLine
        {
            OrderId = orderLine.OrderId,
            ProductId = orderLine.ProductId,
            Quantity = orderLine.Quantity
        };
        await _orderLineService.AddAsync(lineToCreate, "068a5f94-7b85-4831-9d74-b2bf62d460e1");
        return StatusCode(StatusCodes.Status201Created, new { Message = "Order line created" });
    }

    public async Task<IActionResult> Delete(int id)
    {
        var line = await _orderLineService.GetByIdAsync(id);
        if (line == null)
        {
            return NotFound("Order line not found");
        }
        try
        {
            await _orderLineService.DeleteAsync(id);
            return Ok(new { Message = "Order line deleted successfully" });
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPatch("{id:int}")]
    // PATCH http://localhost:5008/api/orderline/id

    public async Task<IActionResult> UpdateOrderLine(int id, [FromBody] OrderLineWithOrderIdDto updatedOrderLine)
    {
        var line = await _orderLineService.GetByIdAsync(id);
        if (line == null)
        {
            return NotFound("Order line not found");
        }
        // Check if the order exists
        var order = await _orderService.GetByIdAsync(updatedOrderLine.OrderId);
        if (order == null)
        {
            return NotFound($"Order with ID {updatedOrderLine.OrderId} not found.");
        }
        line.ProductId = updatedOrderLine.ProductId;
        line.Quantity = updatedOrderLine.Quantity;
        await _orderLineService.UpdateAsync(line, "068a5f94-7b85-4831-9d74-b2bf62d460e1");
        return Ok(new { Message = "Order line updated successfully" });
    }
}

*/