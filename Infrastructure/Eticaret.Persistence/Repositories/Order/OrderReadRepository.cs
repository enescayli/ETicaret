using Eticaret.Application.Repositories;
using Eticaret.Application.Repositories.Order;
using Eticaret.Persistence.Contexts;

namespace Eticaret.Persistence.Repositories.Order;

public class OrderReadRepository : ReadRepository<Domain.Entities.Order>, IOrderReadRepository
{
    public OrderReadRepository(EticaretApiDbContext context) : base(context)
    {
    }
}