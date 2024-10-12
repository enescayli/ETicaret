using Eticaret.Application.Abstraction;
using Eticaret.Application.Repositories;
using Eticaret.Application.Repositories.Order;
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
    
    private readonly IOrderWriteRepository _orderWriteRepository; //Test için
    private readonly IOrderReadRepository _orderReadRepository;
    
    private readonly ICustomerWriteRepository _customerWriteRepository;
    private readonly ICustomerReadRepository _customerReadRepository;

    public ProductsController(IProductWriteRepository productWriteRepository, IProductReadRepository productReadRepository, IOrderWriteRepository orderWriteRepository, IOrderReadRepository orderReadRepository, ICustomerReadRepository customerReadRepository, ICustomerWriteRepository customerWriteRepository)
    {
        _productWriteRepository = productWriteRepository;
        _productReadRepository = productReadRepository;
        _orderWriteRepository = orderWriteRepository;
        _orderReadRepository = orderReadRepository;
        _customerReadRepository = customerReadRepository;
        _customerWriteRepository = customerWriteRepository;
    }
    
    // GET
    [HttpGet]
    public async Task<OkObjectResult> Get()
    {
        return Ok("Hello World!");
    }

}