using Finapp.Models;
using Finapp.Services.Interfaces;

namespace Finapp.Services;

public class DealService : IDealService
{
    public Task<Deal> Create(Deal t)
    {
        throw new NotImplementedException();
    }

    public void Delete(int id)
    {
        throw new NotImplementedException();
    }

    public Task<Deal?> Detail(int id)
    {
        throw new NotImplementedException();
    }

    public bool Exists(int id)
    {
        throw new NotImplementedException();
    }

    public IList<Deal> List()
    {
        throw new NotImplementedException();
    }

    public Deal Update(Deal t)
    {
        throw new NotImplementedException();
    }
}
