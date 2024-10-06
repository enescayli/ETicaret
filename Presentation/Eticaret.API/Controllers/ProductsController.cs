using Eticaret.Application.Abstraction;
using Microsoft.AspNetCore.Mvc;

namespace Eticaret.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController : Controller
{
    private readonly IProductService _productService;

    public ProductsController(IProductService productService)
    {
        _productService = productService;
    }
    
    // GET
    [HttpGet]
    public IActionResult GetProducts()
    {
        _productService.GetProducts();
        return Ok(); 
    }
}