using UpSkills.Applications.Utils;
using UpSkills.DataAccess.ViewModels;
using UpSkills.Persistance.Dto.Courses;

namespace UpSkills.Service.Interfaces.Courses;

public interface ICourseService
{
    public Task<bool> CreateAsync(CourseCreateDto dto);
    public Task<bool> UpdateAsync(long courseId, CourseUpdateDto dto);
    public Task<bool> DeleteAsync(long courseId);
    public Task<CourseViewModel> GetByIdAsync(long courseId);
    public Task<IList<CourseViewModel>> GetAllAsync(PaginationParams @params);
    public Task<long> CountAsync();
    public Task<IList<CourseViewModel>> SearchAsync(string search, PaginationParams @params);
}