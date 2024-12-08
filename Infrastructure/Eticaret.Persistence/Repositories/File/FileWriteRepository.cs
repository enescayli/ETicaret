using Eticaret.Application.Repositories;
using Eticaret.Persistence.Contexts;

namespace Eticaret.Persistence.Repositories;

public class FileWriteRepository : WriteRepository<Domain.Entities.File>, IFileWriteRepository
{
    public FileWriteRepository(EticaretApiDbContext context) : base(context)
    {
    }
}