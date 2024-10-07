using System.Linq.Expressions;
using Eticaret.Domain.Entities.Common;

namespace Eticaret.Application.Repositories;

public interface IReadRepository<T> : IRepository<T> where T : BaseEntity
{
    IQueryable<T> GetAll();
    IQueryable<T> GetWhere(Expression<Func<T, bool>> method); //where şartına uyanları getirir.
        
    Task<T?> GetSingleAsync(Expression<Func<T, bool>> method);
    Task<T?> GetByIdAsync(string id);   
}