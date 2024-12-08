using Eticaret.Application.Repositories;
using Eticaret.Domain.Entities;
using Eticaret.Persistence.Contexts;

namespace Eticaret.Persistence.Repositories;

public class InvoinceFileReadRepository : ReadRepository<InvoiceFile>, IInvoiceFileReadRepository
{
    public InvoinceFileReadRepository(EticaretApiDbContext context) : base(context)
    {
    }
}