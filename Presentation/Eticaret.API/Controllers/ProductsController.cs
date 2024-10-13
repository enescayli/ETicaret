using System.Net;
using Eticaret.Application.Abstraction;
using Eticaret.Application.Repositories;
using Eticaret.Application.Repositories.Order;
using Eticaret.Application.Repositories.Product;
using Eticaret.Application.ViewModels.Products;
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
    public async Task<IActionResult> Get()
    {
        return Ok(_productReadRepository.GetAll(false));
    }
    
    [HttpGet("{id}")] 
    public async Task<IActionResult> Get(string id)
    {
        return Ok(await _productReadRepository.GetByIdAsync(id, false));
    }

    [HttpPost]
    public async Task<IActionResult> Post(VM_CreateProduct productModel)
    {
        if (ModelState.IsValid)
        {
            
        }
            
            
        await _productWriteRepository.AddAsync(new()
        {
            Name = productModel.Name,
            Price = productModel.Price,
            Stock = productModel.Stock,
        });

        await _productWriteRepository.SaveAsync();

        return StatusCode((int)HttpStatusCode.Created);
    }

    [HttpPut]
    public async Task<IActionResult> Put(VM_UpdateProduct productModel)
    {
        var product = await _productReadRepository.GetByIdAsync(productModel.Id);
        if (product == null) return Ok("Product not found");
        
        product.Name = productModel.Name;
        product.Price = productModel.Price;
        product.Stock = productModel.Stock;
        await _productWriteRepository.SaveAsync();

        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        await _productWriteRepository.RemoveAsync(id);
        await _productWriteRepository.SaveAsync();
        return Ok();
    }
}