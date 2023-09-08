using Finapp.Repository.Context;

namespace Finapp.Repository.Interfaces;

public interface IUnitOfWork: IDisposable
{
    FinappContext dbContext { get; }
    void Commit();
    void Detach();
}