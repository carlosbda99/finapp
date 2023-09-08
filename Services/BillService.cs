using Finapp.Models;
using Finapp.Repository;
using Finapp.Repository.Interfaces;
using Finapp.Services.Interfaces;

namespace Finapp.Services;

public class BillService : IBillService
{
    private readonly IUnitOfWork _uow;
    private readonly IBillRepository _billRepository;

    public BillService(
        IUnitOfWork uow,
        IBillRepository billRepository
    )
    {
        _uow = uow;
        _billRepository = billRepository;
    }

    public IList<Bill> List()
    {
        List<Bill> bills = _billRepository.GetAll().ToList();

        return bills;
    }

    public async Task<Bill?> Detail(int id)
    {
        Bill? bill = await _billRepository.Get(bill => bill.Id == id);

        return bill;
    }

    public async Task<Bill> Create(Bill bill)
    {
        Bill billCreated = await _billRepository.Create(bill);

        _uow.Commit();

        return billCreated;
    }

    public Bill Update(Bill bill)
    {
        Bill billUpdated = _billRepository.Update(bill);

        _uow.Commit();

        return billUpdated;
    }

    public async void Delete(int id)
    {
        Bill? bill = await Detail(id);

        if (bill is null) return;

        _billRepository.Delete(bill);

        _uow.Commit();
    }

    public bool Exists(int id)
    {
        return _billRepository.Get(bill => bill.Id == id) is not null;
    }
}