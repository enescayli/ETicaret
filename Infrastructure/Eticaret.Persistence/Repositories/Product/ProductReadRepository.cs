using Eticaret.Application.Repositories.Product;
using Eticaret.Persistence.Contexts;

namespace Eticaret.Persistence.Repositories.Product;

public class ProductReadRepository : ReadRepository<Domain.Entities.Product>, IProductReadRepository
{
    public ProductReadRepository(EticaretApiDbContext context) : base(context)
    {
    }
}