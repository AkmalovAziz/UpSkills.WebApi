using UpSkills.Applications.Utils;
using UpSkills.Domain.Entities.Categories;
using UpSkills.Persistance.Dto.Categories;

namespace UpSkills.Service.Interfaces.Categories;

public interface ICategoryService
{
    public Task<bool> CreateAsync(CategoryCreateDto dto);
    public Task<bool> UpdateAsync(long categoryId, CategoryUpdateDto dto);
    public Task<bool> DeleteAsync(long categoryId);
    public Task<IList<Category>> GetAllAsync(PaginationParams @params);
    public Task<IList<Category>> SearchAsync(string search, PaginationParams @params);
    public Task<Category> GetByIdAsync(long categoryId);
    public Task<long> CountAsync();
}