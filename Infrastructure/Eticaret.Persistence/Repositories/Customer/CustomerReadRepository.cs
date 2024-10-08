using System.Linq.Expressions;
using Eticaret.Application.Repositories;
using Eticaret.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Eticaret.Persistence.Repositories.Customer;

public class CustomerReadRepository : ReadRepository<Domain.Entities.Customer>, ICustomerReadRepository
{
    public CustomerReadRepository(EticaretApiDbContext context) : base(context)
    {
        
    }
} 