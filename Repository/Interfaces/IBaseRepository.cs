using System.Linq.Expressions;

namespace Finapp.Repository.Interfaces;

public interface IBaseRepository<T> where T : class
{
    IQueryable<T> GetAll();
    IQueryable<T> GetAll(Expression<Func<T, bool>> expression);
    Task<T?> Get(Expression<Func<T, bool>> expression);
    Task<T> Create(T entity);
    T Update(T entity);
    void Delete(T entity);
}