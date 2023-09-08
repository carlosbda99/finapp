using Finapp.Models;
using Finapp.Repository;
using Finapp.Repository.Interfaces;
using Finapp.Services.Interfaces;

namespace Finapp.Services;

public class CategoryService : ICategoryService
{
    private readonly IUnitOfWork _uow;
    private readonly ICategoryRepository _categoryRepository;

    public CategoryService(
        IUnitOfWork uow,
        ICategoryRepository categoryRepository
    )
    {
        _uow = uow;
        _categoryRepository = categoryRepository;
    }

    public IList<Category> List()
    {
        List<Category> categories = _categoryRepository.GetAll().ToList();

        return categories;
    }

    public async Task<Category?> Detail(int id)
    {
        Category? category = await _categoryRepository.Get(c => c.Id == id);

        return category;
    }

    public async Task<Category> Create(Category category)
    {
        Category categoryCreated = await _categoryRepository.Create(category);

        _uow.Commit();

        return categoryCreated;
    }

    public Category Update(Category category)
    {
        Category categoryUpdated = _categoryRepository.Update(category);

        _uow.Commit();

        return categoryUpdated;
    }

    public async void Delete(int id)
    {
        Category? category = await Detail(id);

        if (category is null) return;

        _categoryRepository.Delete(category);

        _uow.Commit();
    }

    public bool Exists(int id)
    {
        return _categoryRepository.Get(c => c.Id == id) is not null;
    }
}