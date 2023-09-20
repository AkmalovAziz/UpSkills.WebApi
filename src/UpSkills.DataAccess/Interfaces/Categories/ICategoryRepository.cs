using UpSkills.DataAccess.Commons.Interfaces;
using UpSkills.Domain.Entities.Categories;

namespace UpSkills.DataAccess.Interfaces.Categories;

public interface ICategoryRepository : IRepository<Category, Category>, ISearch<Category>
{
}