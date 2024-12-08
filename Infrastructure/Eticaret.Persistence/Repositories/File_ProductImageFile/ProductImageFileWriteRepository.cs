using Eticaret.Application.Repositories;
using Eticaret.Persistence.Contexts;

namespace Eticaret.Persistence.Repositories;

public class ProductImageFileWriteRepository : WriteRepository<Domain.Entities.ProductImageFile>, IProductIMageFileWriteRepository
{
    public ProductImageFileWriteRepository(EticaretApiDbContext context) : base(context)
    {
    }
}