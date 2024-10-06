using Eticaret.Domain.Entities;

namespace Eticaret.Application.Abstraction;

public interface IProductService
{
    List<Product> GetProducts();
}