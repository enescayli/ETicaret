using Eticaret.Application.Repositories;
using Eticaret.Persistence.Contexts;

namespace Eticaret.Persistence.Repositories.Customer;


public class CustomerWriteRepository : WriteRepository<Domain.Entities.Customer>, ICustomerWriteRepository
{
    public CustomerWriteRepository(EticaretApiDbContext context) : base(context)
    {
    }
}