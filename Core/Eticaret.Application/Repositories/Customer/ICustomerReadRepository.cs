namespace Eticaret.Application.Repositories;

public interface ICustomerReadRepository : IReadRepository<Domain.Entities.Customer> //Customer'ı yukarıdaki import edip. Direkt geçmekte mümkün ancak bu haliyle name space'den (write içinde dahil olmak üzere : Customer'ibaresi kaldırılmalıdır.)
{
    
}