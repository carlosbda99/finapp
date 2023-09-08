using Finapp.Models;
using Finapp.Repository.Interfaces;

namespace Finapp.Repository;

public class BillRepository : BaseRepository<Bill>, IBillRepository
{
    public BillRepository(IUnitOfWork uow) : base(uow) { }
}