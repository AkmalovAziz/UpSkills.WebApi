using UpSkills.Applications.Exceptions.Categories;
using UpSkills.Applications.Utils;
using UpSkills.DataAccess.Interfaces.Categories;
using UpSkills.DataAccess.Interfaces.Courses;
using UpSkills.Domain.Entities.Categories;
using UpSkills.Persistance.Dto.Categories;
using UpSkills.Persistance.Helpers;
using UpSkills.Service.Interfaces.Categories;
using UpSkills.Service.Interfaces.Commons;

namespace UpSkills.Service.Service.Categories;

public class CategoryService : ICategoryService
{
    private IPaginator _paginator;
    private ICoursRepository _course;
    private ICategoryRepository _repository;
    private IFileService _fileservice;

    public CategoryService(ICategoryRepository repository, IPaginator paginator,
        IFileService fileservice, ICoursRepository coursRepository)
    {
        this._repository = repository;
        this._fileservice = fileservice;
        this._paginator = paginator;
        this._course = coursRepository;
    }
    public async Task<bool> CreateAsync(CategoryCreateDto dto)
    {
        var category = new Category();
        category.CategoryName = dto.CategoryName;
        category.Description = dto.Description;
        string image = await _fileservice.UploadImageAsync(dto.ImagePath);
        category.ImagePath = image;
        category.CreatedAt = category.UpdatedAt = TimeHelpers.GetDateTime();
        var result = await _repository.CreateAsync(category);

        return result > 0;
    }

    public async Task<bool> DeleteAsync(long categoryId)
    {
        var category = await _repository.GetIdAsync(categoryId);
        if (category is null) throw new CategoryNotFoundException();
        if (category.ImagePath is not null)
        {
            var delete = await _fileservice.DeleteImageAsync(category.ImagePath);
        }
        var course = await _course.DeleteAsync(categoryId);
        var result = await _repository.DeleteAsync(categoryId);

        return result > 0;
    }

    public async Task<IList<Category>> GetAllAsync(PaginationParams @params)
    {
        var category = await _repository.GetAllAsync(@params);
        var count = await _repository.CountAsync();
        _paginator.Paginate(count, @params);

        return category;
    }

    public async Task<Category> GetByIdAsync(long categoryId)
    {
        var category = await _repository.GetIdAsync(categoryId);
        if (category is null) throw new CategoryNotFoundException();

        return category;
    }

    public async Task<bool> UpdateAsync(long categoryId, CategoryUpdateDto dto)
    {
        var category = await _repository.GetIdAsync(categoryId);
        if (category is null) throw new CategoryNotFoundException();

        category.Description = dto.Description;
        category.CategoryName = dto.CategoryName;
        if (dto.ImagePath is not null)
        {
            var deleteResult = await _fileservice.DeleteImageAsync(category.ImagePath);
            if (deleteResult == false) throw new FileNotFoundException();

            string newImage = await _fileservice.UploadImageAsync(dto.ImagePath);
            category.ImagePath = newImage;
        }

        category.UpdatedAt = TimeHelpers.GetDateTime();
        var result = await _repository.UpdateAsync(categoryId, category);

        return result > 0;
    }

    public async Task<long> CountAsync() => await _repository.CountAsync();

    public async Task<IList<Category>> SearchAsync(string search, PaginationParams @params)
    {
        var category = await _repository.SearchAsync(search, @params);
        var count = await _repository.CountAsync();
        _paginator.Paginate(count, @params);

        return category;
    }
}