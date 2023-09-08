using System.Linq.Expressions;
using Finapp.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Finapp.Repository;

public class BaseRepository<T> : IBaseRepository<T> where T : class
{
    protected readonly IUnitOfWork _uow;
    private DbSet<T> _entities;

    public BaseRepository(IUnitOfWork uow)
    {
        _uow = uow;
        _entities = _uow.dbContext.Set<T>();
    }


    public async Task<T> Create(T entity)
    {
        await _entities.AddAsync(entity);
        
        return entity;
    }

    public void Delete(T entity)
    {
        _entities.Remove(entity);
    }

    public async Task<T?> Get(Expression<Func<T, bool>> expression)
    {
        T? entity = await _entities.Where(expression).FirstOrDefaultAsync();

        return entity;
    }

    public IQueryable<T> GetAll()
    {
        return _entities.AsQueryable<T>();
    }

    public IQueryable<T> GetAll(Expression<Func<T, bool>> expression)
    {
        return _entities.Where(expression);
    }

    public T Update(T entity)
    {
        _entities.Update(entity);

        return entity;
        
    }
}
