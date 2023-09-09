using UpSkills.DataAccess.Commons.Interfaces;
using UpSkills.DataAccess.ViewModels;
using UpSkills.Domain.Entities.Courses;

namespace UpSkills.DataAccess.Interfaces.Courses;

public interface ICoursRepository : IRepository<Course, CourseViewModel>,
    ISearch<CourseViewModel>
{
}