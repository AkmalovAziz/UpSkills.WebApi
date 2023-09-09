using UpSkills.Applications.Utils;
using UpSkills.DataAccess.Interfaces.Courses;
using UpSkills.DataAccess.ViewModels;
using UpSkills.Domain.Entities.Courses;

namespace UpSkills.DataAccess.Repositories.Courses;

public class CourseRepository : ICoursRepository
{
    public Task<long> CountAsync()
    {
        throw new NotImplementedException();
    }

    public Task<int> CreateAsync(Course entity)
    {
        throw new NotImplementedException();
    }

    public Task<int> DeleteAsync(long id)
    {
        throw new NotImplementedException();
    }

    public Task<IList<CourseViewModel>> GetAllAsync(PaginationParams @params)
    {
        throw new NotImplementedException();
    }

    public Task<CourseViewModel> GetByIdAsync(long id)
    {
        throw new NotImplementedException();
    }

    public Task<Course> GetIdAsync(long id)
    {
        throw new NotImplementedException();
    }

    public Task<IList<CourseViewModel>> SearchAsync(string search, PaginationParams @params)
    {
        throw new NotImplementedException();
    }

    public Task<int> UpdateAsync(long id, Course entity)
    {
        throw new NotImplementedException();
    }
}