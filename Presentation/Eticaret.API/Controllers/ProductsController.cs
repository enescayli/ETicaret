using Eticaret.Application.Abstraction;
using Eticaret.Application.Repositories.Product;
using Eticaret.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Eticaret.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController : Controller
{
    private readonly IProductWriteRepository _productWriteRepository;
    private readonly IProductReadRepository _productReadRepository;

    public ProductsController(IProductWriteRepository productWriteRepository, IProductReadRepository productReadRepository)
    {
        _productWriteRepository = productWriteRepository;
        _productReadRepository = productReadRepository;
    }
    
    // GET
    [HttpGet]
    public async Task Get()
    {
        await _productWriteRepository.AddRangeAsync(new()
        {
            new()
            { Id = Guid.NewGuid(), Name = "üRÜN X", Price = 200, Stock = 20, CreateDate = DateTime.UtcNow },
            
        });
        
        await _productWriteRepository.SaveAsync();
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(String id)
    {
        try
        {
            var product = await _productReadRepository.GetByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}