using System.Linq.Expressions;
using Eticaret.Domain.Entities.Common;

namespace Eticaret.Application.Repositories;

public interface IReadRepository<T> : IRepository<T> where T : BaseEntity
{
    IQueryable<T> GetAll(bool tracking = true);
    IQueryable<T> GetWhere(Expression<Func<T, bool>> method, bool tracking = true); //where şartına uyanları getirir.
        
    Task<T?> GetSingleAsync(Expression<Func<T, bool>> method,bool tracking = true);
    Task<T?> GetByIdAsync(string id, bool tracking = true);   
}