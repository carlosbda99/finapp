using Finapp.Models;
using Finapp.Services.Interfaces;

namespace Finapp.Services;

public class WalletService : IWalletService
{
    public Task<Wallet> Create(Wallet t)
    {
        throw new NotImplementedException();
    }

    public void Delete(int id)
    {
        throw new NotImplementedException();
    }

    public Task<Wallet?> Detail(int id)
    {
        throw new NotImplementedException();
    }

    public bool Exists(int id)
    {
        throw new NotImplementedException();
    }

    public IList<Wallet> List()
    {
        throw new NotImplementedException();
    }

    public Wallet Update(Wallet t)
    {
        throw new NotImplementedException();
    }
}
