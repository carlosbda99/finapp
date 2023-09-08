using Finapp.Models;
using Finapp.Repository.Interfaces;

namespace Finapp.Repository;

public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
{
    public CategoryRepository(IUnitOfWork uow) : base(uow) { }
}