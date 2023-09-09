using Finapp.Models;
using Finapp.Repository.Interfaces;
using Finapp.Services.Interfaces;

namespace Finapp.Services;

public class CardService : ICardService
{
    private readonly IUnitOfWork _uow;
    private readonly ICardRepository _cardRepository;

    public CardService(
        IUnitOfWork uow,
        ICardRepository cardRepository
    )
    {
        _uow = uow;
        _cardRepository = cardRepository;
    }

    public Task<Card> Create(Card t)
    {
        throw new NotImplementedException();
    }

    public void Delete(int id)
    {
        throw new NotImplementedException();
    }

    public Task<Card?> Detail(int id)
    {
        throw new NotImplementedException();
    }

    public bool Exists(int id)
    {
        throw new NotImplementedException();
    }

    public IList<Card> List()
    {
        throw new NotImplementedException();
    }

    public Card Update(Card t)
    {
        throw new NotImplementedException();
    }
}