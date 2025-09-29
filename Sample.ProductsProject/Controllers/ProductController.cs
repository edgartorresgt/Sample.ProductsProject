using Microsoft.AspNetCore.Mvc;
using Sample.ProductsSample.Infraestructure.Interfaces;

namespace Sample.ProductsProject.Controllers;

[ApiController]
public class ProductController
{
    private readonly IProductService _productService;
    private const string ApiKey = "12345";
    public ProductController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpGet]
    [Route("api/products")]
    public async Task<IActionResult> GetProducts([FromHeader(Name = "X-API-KEY")] string apiKey)
    {
        if (apiKey != ApiKey)
        {
            return new UnauthorizedObjectResult(new { message = "Invalid API Key" });
        }

        var products = await _productService.GetProductAsync();
        return new OkObjectResult(products);
    }
}