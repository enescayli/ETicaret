using Eticaret.Application.Repositories;
using Eticaret.Persistence.Contexts;

namespace Eticaret.Persistence.Repositories;

public class ProductImageFileReadRepository : ReadRepository<Domain.Entities.ProductImageFile>, IProductImageFileReadRepository
{
    public ProductImageFileReadRepository(EticaretApiDbContext context) : base(context)
    {
    }
}