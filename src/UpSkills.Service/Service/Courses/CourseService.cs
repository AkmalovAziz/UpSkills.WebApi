using UpSkills.Applications.Exceptions.Courses;
using UpSkills.Applications.Utils;
using UpSkills.DataAccess.Interfaces.Courses;
using UpSkills.DataAccess.ViewModels;
using UpSkills.Domain.Entities.Courses;
using UpSkills.Persistance.Dto.Courses;
using UpSkills.Persistance.Helpers;
using UpSkills.Service.Interfaces.Commons;
using UpSkills.Service.Interfaces.Courses;

namespace UpSkills.Service.Service.Courses;

public class CourseService : ICourseService
{
    private ICoursRepository _repository;
    private IPaginator _paginator;
    private IFileService _fileservice;
    private IIdentityService _identity;

    public CourseService(ICoursRepository repository, IFileService fileService,
        IPaginator paginator, IIdentityService identity)
    {
        this._repository = repository;
        this._paginator = paginator;
        this._fileservice = fileService;
        this._identity = identity;
    }
    public async Task<long> CountAsync() => await _repository.CountAsync();

    public async Task<bool> CreateAsync(CourseCreateDto dto)
    {
        var course = new Course();
        course.PricePerMonth = dto.PricePerMonth;
        course.CourseName = dto.Name;
        course.CategoryId = dto.CategoryId;

        if (dto.ImagePath is null) throw new FileNotFoundException();
        string image = await _fileservice.UploadImageAsync(dto.ImagePath);
        course.ImagePath = image;
        course.Description = dto.Description;
        course.CreatedAt = course.UpdatedAt = TimeHelpers.GetDateTime();
        var result = await _repository.CreateAsync(course);

        return result > 0;
    }

    public async Task<bool> DeleteAsync(long courseId)
    {
        var course = await _repository.GetIdAsync(courseId);
        if (course is null) throw new CourseNotFoundException();

        var result = await _repository.DeleteAsync(courseId);
        if (course.ImagePath is not null)
        {
            var image = await _fileservice.DeleteImageAsync(course.ImagePath);
        }

        return result > 0;
    }

    public async Task<IList<CourseViewModel>> GetAllAsync(PaginationParams @params)
    {
        var course = await _repository.GetAllAsync(@params);
        var count = await _repository.CountAsync();
        _paginator.Paginate(count, @params);

        return course;
    }

    public async Task<CourseViewModel> GetByIdAsync(long courseId)
    {
        var course = await _repository.GetByIdAsync(courseId);
        if (course is null) throw new CourseNotFoundException();

        return course;
    }

    public async Task<IList<CourseViewModel>> SearchAsync(string search, PaginationParams @params)
    {
        var result = await _repository.SearchAsync(search, @params);

        return result;
    }

    public async Task<bool> UpdateAsync(long courseId, CourseUpdateDto dto)
    {
        var course = await _repository.GetIdAsync(courseId);
        if (course is null) throw new CourseNotFoundException();

        course.PricePerMonth = dto.PricePerMonth;
        course.Description = dto.Description;
        course.CourseName = dto.Name;
        if(course.ImagePath is not null)
        {
            var delete = await _fileservice.DeleteImageAsync(course.ImagePath);
            if (delete == false) throw new FileNotFoundException();

            string newImage = await _fileservice.UploadImageAsync(dto.ImagePath);
            course.ImagePath = newImage;
        }
        course.UpdatedAt = TimeHelpers.GetDateTime();
        var result = await _repository.UpdateAsync(courseId, course);

        return result > 0;
    }
}