using Eticaret.Application.Repositories.Order;
using Eticaret.Persistence.Contexts;

namespace Eticaret.Persistence.Repositories.Order;

public class OrderWriteRepository : WriteRepository<Domain.Entities.Order>, IOrderWriteRepository
{
    public OrderWriteRepository(EticaretApiDbContext context) : base(context)
    {
    }
}