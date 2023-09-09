using UpSkills.Applications.Utils;
using UpSkills.DataAccess.Interfaces.Categories;
using UpSkills.Domain.Entities.Categories;

namespace UpSkills.DataAccess.Repositories.Categories;

public class CategoryRepository : ICategoryRepository
{
    public Task<long> CountAsync()
    {
        throw new NotImplementedException();
    }

    public Task<int> CreateAsync(Category entity)
    {
        throw new NotImplementedException();
    }

    public Task<int> DeleteAsync(long id)
    {
        throw new NotImplementedException();
    }

    public Task<IList<Category>> GetAllAsync(PaginationParams @params)
    {
        throw new NotImplementedException();
    }

    public Task<Category> GetByIdAsync(long id)
    {
        throw new NotImplementedException();
    }

    public Task<Category> GetIdAsync(long id)
    {
        throw new NotImplementedException();
    }

    public Task<int> UpdateAsync(long id, Category entity)
    {
        throw new NotImplementedException();
    }
}