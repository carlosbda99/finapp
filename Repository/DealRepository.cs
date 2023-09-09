using Finapp.Models;
using Finapp.Repository.Interfaces;

namespace Finapp.Repository;

public class DealRepository : BaseRepository<Deal>, IDealRepository
{
    public DealRepository(IUnitOfWork uow) : base(uow) { }
}