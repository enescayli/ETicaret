using Eticaret.Application.Repositories.Product;
using Eticaret.Persistence.Contexts;

namespace Eticaret.Persistence.Repositories.Product;

public class ProductWriteRepository : WriteRepository<Domain.Entities.Product>, IProductWriteRepository
{
    public ProductWriteRepository(EticaretApiDbContext context) : base(context)
    {
    }
}