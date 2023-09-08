using Finapp.Models;

namespace Finapp.Services.Interfaces;

public interface IBaseService<T> where T: class
{
    public IList<T> List();
    
    public Task<T?> Detail(int id);

    public Task<T> Create(T t);

    public T Update(T t);

    public void Delete(int id);

    public bool Exists(int id);
}