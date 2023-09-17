using UpSkills.DataAccess.Commons.Interfaces;
using UpSkills.DataAccess.ViewModels;
using UpSkills.Domain.Entities.Users;

namespace UpSkills.DataAccess.Interfaces.Users;

public interface IUserRepository : IRepository<User, UserViewModel>, ISearch<UserViewModel>
{
    public Task<User?> GetByEmailAsync(string email);
}