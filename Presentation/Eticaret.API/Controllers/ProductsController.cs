using System.Net;
using Eticaret.Application.Abstraction;
using Eticaret.Application.Repositories;
using Eticaret.Application.Repositories.Order;
using Eticaret.Application.Repositories.Product;
using Eticaret.Application.RequestParameters;
using Eticaret.Application.Services;
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
    private readonly IWebHostEnvironment _webHostEnvironment;
    private readonly IFileService _fileService;
    
    public ProductsController(
        IProductWriteRepository productWriteRepository, 
        IProductReadRepository productReadRepository,
        IWebHostEnvironment webHostEnvironment,
        IFileService fileService
        )
    {
        _productWriteRepository = productWriteRepository;
        _productReadRepository = productReadRepository;
        _webHostEnvironment = webHostEnvironment;
        _fileService = fileService;
    }
    
    // GET
    [HttpGet]
    public async Task<IActionResult> Get([FromQuery]Pagination pagination)
    {
        var totalCount = _productReadRepository.GetAll(false).Count();
        var products = _productReadRepository.GetAll(false).Select(
            p => new
            {
                p.Id,
                p.Name,
                p.Stock, 
                p.Price,
                p.CreatedDate, 
                p.UpdatedDate
            }).Skip(pagination.Page * pagination.Size).Take(pagination.Size); 

        return Ok(new
            {
                totalCount, 
                products
            });
    }
    
    [HttpGet("{id}")] 
    public async Task<IActionResult> Get(string id)
    {
        return Ok(await _productReadRepository.GetByIdAsync(id, false));
    }

    [HttpPost]
    public async Task<IActionResult> Post(VM_CreateProduct productModel)
    {
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
    [HttpPost("[action]")] //controller/action
    public async Task<IActionResult> Upload()
    {
        await _fileService.UploadAsync("resource/product-images", Request.Form.Files);
        return Ok();
        /*
        string uploadPath = Path.Combine(_webHostEnvironment.WebRootPath, "resource/product-images");

        if(!Directory.Exists(uploadPath))
            Directory.CreateDirectory(uploadPath);
        Random r = new Random();
        foreach (var file in Request.Form.Files)
        {
            try
            {
                var specificFileName = (DateTime.Now + r.Next(10000,99999).ToString() +"." +file.FileName).Replace(" ","");
                var fullPath = Path.Combine(uploadPath, specificFileName);

                using FileStream fileStream = new (fullPath, FileMode.Create, FileAccess.Write, FileShare.None, 1024* 1024);
                await file.CopyToAsync(fileStream);
                await fileStream.FlushAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        return Ok();
        */
    }
}