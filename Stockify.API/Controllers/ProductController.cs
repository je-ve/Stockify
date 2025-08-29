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
        var allProducts = await _productService.GetAllAsync();
        var products = allProducts
            .Select(p => new ProductDto
            {
                Name = p.Name,
                SerialNumber = p.SerialNumber
            })
            .ToList();
        return Ok(products);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        var res = await _productService.GetByIdAsync(id);
        if (res == null) return NotFound("Product not found");
        var product = new ProductDto() { Name = res.Name, SerialNumber = res.SerialNumber };
        return Ok(product);
    }



    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    // POST http://localhost:5008/api/product/    
    public async Task<IActionResult> Create([FromBody] ProductDto product)
    {
        var productToCreate = new Product
        {
            SerialNumber = product.SerialNumber,
            Name = product.Name
        };

        await _productService.AddAsync(productToCreate, "068a5f94-7b85-4831-9d74-b2bf62d460e1");
        return StatusCode(StatusCodes.Status201Created, new { Message = "Product created" });
    }

    [HttpPatch("{id:int}")]
    // PATCH http://localhost:5008/api/product/id    
    public async Task<IActionResult> UpdateProduct(int id, [FromBody] ProductDto updatedProduct)
    {
        var product = await _productService.GetByIdAsync(id);

        if (product == null)
        {
            return StatusCode(StatusCodes.Status500InternalServerError);
        }

        product.SerialNumber = updatedProduct.SerialNumber;
        product.Name = updatedProduct.Name;
        await _productService.UpdateAsync(product, "068a5f94-7b85-4831-9d74-b2bf62d460e1");
        return Ok(new { Message = "Product updated" });
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var product = await _productService.GetByIdAsync(id);
        if (product == null) return NotFound("Product not found");
        await _productService.DeleteAsync(id);
        return Ok(new { Message = "Product deleted" });
    }
}
