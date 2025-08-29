using Microsoft.AspNetCore.Mvc;
using Stockify.Logic;
using Stockify.Objects;
using Stockify.API.Dto;
namespace Stockify.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OrderActionController : ControllerBase
{
    private readonly IOrderLineService _orderLineService;
    private readonly IOrderService _orderService;
    private readonly IOrderActionService _orderActionService;
    private readonly IProductService _productService;
    public OrderActionController(IOrderLineService orderLineService, IOrderService orderService, IOrderActionService orderActionService, IProductService productService)
    {
        _orderLineService = orderLineService;
        _orderService = orderService;
        _orderActionService = orderActionService;
        _productService = productService;
    }

    [HttpPost("add")]
    public async Task<IActionResult> AddOrderAction([FromBody] CreateOrderActionDto orderActionDto)
    {

        var order = await _orderService.GetByIdAsync(orderActionDto.OrderId);
        if (order == null)
        {
            return NotFound("Order not found.");
        }
        if (order.Status == OrderStatus.Delivered)
        {
            return BadRequest("Order is already delivered and cannot be modified.");
        }

        if (orderActionDto.orderActionType < 1 || orderActionDto.orderActionType > 2)
        {
            return BadRequest("Invalid order action type.");
        }

        await _orderActionService.CreateOrderAction(orderActionDto.OrderId, (OrderActionType)orderActionDto.orderActionType);

        return Ok("Order action added successfully.");
    }
}

