using Finapp.Models;
using Finapp.Repository.Interfaces;

namespace Finapp.Repository;

public class CardRepository : BaseRepository<Card>, ICardRepository
{
    public CardRepository(IUnitOfWork uow) : base(uow) { }
}