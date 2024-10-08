using System.Linq.Expressions;
using Eticaret.Application.Repositories;
using Eticaret.Domain.Entities.Common;
using Eticaret.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Eticaret.Persistence.Repositories;

public class ReadRepository<T> : IReadRepository<T> where T : BaseEntity
{
    private readonly EticaretApiDbContext _context;

    public ReadRepository(EticaretApiDbContext context)
    {
        _context = context;
    }
    
    public DbSet<T> Table => _context.Set<T>();

    public IQueryable<T> GetAll() => Table;

    public IQueryable<T> GetWhere(Expression<Func<T, bool>> method)
    => Table.Where(method);

    public async Task<T?> GetSingleAsync(Expression<Func<T, bool>> method)
    => await Table.FirstOrDefaultAsync(method);
  
    public async Task<T?> GetByIdAsync(string id)
        => await Table.FindAsync(Guid.Parse(id));
}