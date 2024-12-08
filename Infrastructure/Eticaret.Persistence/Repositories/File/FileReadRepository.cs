using Eticaret.Application.Repositories;
using Eticaret.Persistence.Contexts;

namespace Eticaret.Persistence.Repositories;

public class FileReadRepository : ReadRepository<Domain.Entities.File>, IFileReadRepository
{
    public FileReadRepository(EticaretApiDbContext context) : base(context)
    {
    }
}