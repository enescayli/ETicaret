using Eticaret.Application.Repositories;
using Eticaret.Domain.Entities;
using Eticaret.Persistence.Contexts;

namespace Eticaret.Persistence.Repositories;

public class InvoinceFileWriteRepository : WriteRepository<InvoiceFile>, IInvoiceFileWriteRepository
{
    public InvoinceFileWriteRepository(EticaretApiDbContext context) : base(context)
    {
    }
}