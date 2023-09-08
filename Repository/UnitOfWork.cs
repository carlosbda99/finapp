using Finapp.Repository.Context;
using Finapp.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Finapp.Repository;

public class UnitOfWork : IUnitOfWork
{
    public FinappContext dbContext { get; }

    public UnitOfWork(FinappContext context)
    {
        dbContext = context;
    }

    public void Commit()
    {
        dbContext.SaveChanges();
    }

    public void Detach()
    {
        foreach (var entity in dbContext.ChangeTracker.Entries())
        {
            entity.State = EntityState.Detached;
        }
    }

    public void Dispose()
    {
        dbContext.Dispose();
    }
}