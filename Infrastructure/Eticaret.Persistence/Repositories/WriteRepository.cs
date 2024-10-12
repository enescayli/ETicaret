using Eticaret.Application.Repositories;
using Eticaret.Domain.Entities.Common;
using Eticaret.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Eticaret.Persistence.Repositories;

public class WriteRepository<T> : IWriteRepository<T> where T :  BaseEntity
{
    private readonly EticaretApiDbContext _context;

    public WriteRepository(EticaretApiDbContext context)
    {
        _context = context;
    }
    public DbSet<T> Table  =>  _context.Set<T>();
    public async Task<bool> AddAsync(T model)
    {
      EntityEntry entityEntry =  await Table.AddAsync(model);
      
      return entityEntry.State == EntityState.Added;
    }

    public async Task<bool>  AddRangeAsync(List<T> data) 
    {
        await Table.AddRangeAsync(data);
        return true;
    }

    public bool Remove(T model)
    {
       EntityEntry entityEntry =  Table.Remove(model);
       return  entityEntry.State == EntityState.Deleted;
    }

    public bool RemoveRange(List<T> data)
    {
        Table.RemoveRange(data);
        return true;
    }

    public async Task<bool> RemoveAsync(string id)
    {
      T model =  await Table.FirstOrDefaultAsync(data => data.Id == Guid.Parse(id)) ?? throw new Exception("Not found");
       return Remove(model);
    }

    public bool Update(T model)
    {
      EntityEntry entityEntry =  Table.Update(model);    
      return entityEntry.State == EntityState.Modified;
    }

    public async Task<int> SaveAsync() => await _context.SaveChangesAsync();
}