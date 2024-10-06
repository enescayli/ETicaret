using Eticaret.Application.Abstraction;
using Eticaret.Domain.Entities;

namespace Eticaret.Persistence.Concretes;

public class ProductService : IProductService
{
    public List<Product> GetProducts() 
        => new()
        {
            new Product() { Id = Guid.NewGuid(), Name =  "Ürün 1", Price = 200, Stock = 20},
            new Product() { Id = Guid.NewGuid(), Name =  "Ürün 2", Price = 260, Stock = 230},
            new Product() { Id = Guid.NewGuid(), Name =  "Ürün 3", Price = 240, Stock = 120},
            new Product() { Id = Guid.NewGuid(), Name =  "Ürün 4", Price = 204, Stock = 420},
            new Product() { Id = Guid.NewGuid(), Name =  "Ürün 5", Price = 220, Stock = 200},
        };
}