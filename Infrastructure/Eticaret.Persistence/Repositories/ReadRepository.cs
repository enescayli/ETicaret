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

    public IQueryable<T> GetAll(bool tracking = true)
    {
        var query = Table.AsQueryable();
        if(!tracking)
            query = query.AsNoTracking(); 
        return query;
    }

    /*
    public void Track(IQueryable<T> query, bool tracking)
    {
        if(!tracking)
            query = query.AsNoTracking();
        
        // and         Track(query, tracking) ..
    }  */

    public IQueryable<T> GetWhere(Expression<Func<T, bool>> method, bool tracking = true)
    {
        var query = Table.Where(method);
         if(!tracking)
             query = query.AsNoTracking();
         
         return query;
    }


    public async Task<T?> GetSingleAsync(Expression<Func<T, bool>> method, bool tracking = true)
    {
        var query = Table.AsQueryable();
        if(!tracking)
            query = Table.AsNoTracking();
        return await query.FirstOrDefaultAsync(method);
    }


    public async Task<T?> GetByIdAsync(string id, bool tracking = true)
    {
        var query = Table.AsQueryable();
        if(!tracking)
            query = Table.AsNoTracking();

        return await query.FirstOrDefaultAsync(data => data.Id == Guid.Parse(id))!;
    }

}