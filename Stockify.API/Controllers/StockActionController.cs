using Microsoft.AspNetCore.Mvc;
using Stockify.Logic;
using Stockify.Objects;
using Stockify.API.Dto;
namespace Stockify.API.Controllers;


[Route("api/[controller]")]
[ApiController]
public class StockActionController : ControllerBase
{
    private readonly IOrderLineService _orderLineService;
    private readonly IOrderService _orderService;
    private readonly IStockActionService _stockActionService;
    private readonly IProductService _productService;
    public StockActionController(IOrderLineService orderLineService, IOrderService orderService, IStockActionService stockActionService, IProductService productService)
    {
        _orderLineService = orderLineService;
        _orderService = orderService;
        _stockActionService = stockActionService;
        _productService = productService;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var lines = await _stockActionService.GetAllAsync();
        return Ok(lines);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        var action = await _stockActionService.GetByIdAsync(id);
        if (action == null) return NotFound("Stockaction not found");
        return Ok(action);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    // POST http://localhost:5008/api/stockaction/
    public async Task<IActionResult> Create([FromBody] StockActionDto stockAction)
    {
        if (stockAction == null)
        {
            return BadRequest("Invalid stock action data.");
        }
        // Check if the order exists
        var product = await _productService.GetByIdAsync(stockAction.productId);
        if (product == null)
        {
            return NotFound($"Order with ID {stockAction.productId} not found.");
        }

        if(stockAction.quantity <= 0)
        {
            return BadRequest("Quantity must be greater than zero.");
        }

        if(stockAction.type != 1 && stockAction.type != -1) {
            return BadRequest("Invalid stock action type. Only 1 or -1 are allowed.");
        }

        var actionToCreate = new StockAction
        {
            ProductId = stockAction.productId,
            Quantity = stockAction.quantity,
            Type = (StockActionType)stockAction.type
        };

        await _stockActionService.AddAsync(actionToCreate);
        return StatusCode(StatusCodes.Status201Created, new { Message = "Stock action created" });
    }

}

