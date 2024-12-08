using System.Net;
using Eticaret.Application.Abstraction;
using Eticaret.Application.Repositories;
using Eticaret.Application.Repositories.Order;
using Eticaret.Application.Repositories.Product;
using Eticaret.Application.RequestParameters;
using Eticaret.Application.Services;
using Eticaret.Application.ViewModels.Products;
using Eticaret.Domain.Entities;
using Eticaret.Persistence.Repositories;
using Microsoft.AspNetCore.Mvc;
using File = Eticaret.Domain.Entities.File;

namespace Eticaret.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController : Controller
{
    private readonly IProductWriteRepository _productWriteRepository;
    private readonly IProductReadRepository _productReadRepository;
    private readonly IWebHostEnvironment _webHostEnvironment;
    private readonly IFileService _fileService;
    private readonly IFileWriteRepository _fileWriteRepository;
    private readonly IFileReadRepository _fileReadRepository;
    private readonly IProductImageFileReadRepository _productImageFileReadRepository;
    private readonly IProductIMageFileWriteRepository _productIMageFileWriteRepository;
    private readonly IInvoiceFileReadRepository _invoiceFileReadRepository;
    private readonly IInvoiceFileWriteRepository _invoiceFileWriteRepository;
    
    
    public ProductsController(
        IProductWriteRepository productWriteRepository, 
        IProductReadRepository productReadRepository,
        IWebHostEnvironment webHostEnvironment,
        IFileService fileService,
        IFileWriteRepository fileWriteRepository,
        IFileReadRepository fileReadRepository,
        IProductImageFileReadRepository productImageFileReadRepository,
        IProductIMageFileWriteRepository productIMageFileWriteRepository,
        IInvoiceFileReadRepository invoiceFileReadRepository,
        IInvoiceFileWriteRepository invoiceFileWriteRepository

        
        )
    {
        _productWriteRepository = productWriteRepository;
        _productReadRepository = productReadRepository;
        _webHostEnvironment = webHostEnvironment;
        _fileService = fileService;
        _fileWriteRepository = fileWriteRepository;
        _fileReadRepository = fileReadRepository;
        _productImageFileReadRepository = productImageFileReadRepository;
        _productImageFileReadRepository = productImageFileReadRepository;
        _productIMageFileWriteRepository = productIMageFileWriteRepository;
        _invoiceFileReadRepository = invoiceFileReadRepository;
        _invoiceFileWriteRepository = invoiceFileWriteRepository;
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
       var  data = await _fileService.UploadAsync("resource/product-images", Request.Form.Files);
       
       /*
       var result = await _productIMageFileWriteRepository.AddRangeAsync(data.Select(d => 
           new ProductImageFile()
           {
               FileName = d.fileName,
               Path = d.path 
           }).ToList());

       await _productWriteRepository.SaveAsync();*/
       
       /*
       var result = await _invoiceFileWriteRepository.AddRangeAsync(data.Select(d => 
           new InvoiceFile()
           {
               FileName = d.fileName,
               Path = d.path,
               Price = new Random().Next()
           }).ToList());

       await _invoiceFileWriteRepository.SaveAsync(); */
       
       
       var result = await _fileWriteRepository.AddRangeAsync(data.Select(d => 
           new File()
           {
               FileName = d.fileName,
               Path = d.path
           }).ToList());

       await _fileWriteRepository.SaveAsync();  
       
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