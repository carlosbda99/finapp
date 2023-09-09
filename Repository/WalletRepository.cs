using Finapp.Models;
using Finapp.Repository.Interfaces;

namespace Finapp.Repository;

public class WalletRepository : BaseRepository<Wallet>, IWalletRepository
{
    public WalletRepository(IUnitOfWork uow) : base(uow) { }
}
