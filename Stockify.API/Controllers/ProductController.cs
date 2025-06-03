using Microsoft.AspNetCore.Mvc;
using Stockify.Logic;
using Stockify.Objects;
using Stockify.API.Dto;
namespace Stockify.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductController : ControllerBase
{

    private readonly IProductService _productService;

    public ProductController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var products = await _productService.GetAllAsync();
        return Ok(products);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        var product = await _productService.GetByIdAsync(id);
        return Ok(product);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    // POST http://localhost:5008/api/product/
    // BODY: {YOUR JSON BODY --> zie CarsApiExample.http file}
    public async Task<IActionResult> Create([FromBody] ProductDto product)
    {
        var productToCreate = new Product
        {
            SerialNumber = product.SerialNumber,
            Name = product.Name
        };

        await _productService.AddAsync(productToCreate);
        //send a custom statuscode
        return StatusCode(StatusCodes.Status201Created, new { Message = "Product created" });
    }

    [HttpPatch("{id:int}")]
    // PATCH http://localhost:5008/api/product/id
    // BODY: {YOUR JSON BODY --> zie CarsApiExample.http file}
    public async Task<IActionResult> UpdateDescription(int id, [FromBody] ProductDto updatedProduct)
    {
        var product = await _productService.GetByIdAsync(id);

        if (product != null)
        {
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
        return Ok(new { Message = "Car updated" });
    }
}
