using UpSkills.Applications.Utils;
using UpSkills.DataAccess.Interfaces.Users;
using UpSkills.DataAccess.ViewModels;
using UpSkills.Domain.Entities.Users;

namespace UpSkills.DataAccess.Repositories.Users;

public class UserRepository : IUserRepository
{
    public Task<long> CountAsync()
    {
        throw new NotImplementedException();
    }

    public Task<int> CreateAsync(User entity)
    {
        throw new NotImplementedException();
    }

    public Task<int> DeleteAsync(long id)
    {
        throw new NotImplementedException();
    }

    public Task<IList<UserViewModel>> GetAllAsync(PaginationParams @params)
    {
        throw new NotImplementedException();
    }

    public Task<User?> GetByEmailAsync(string email)
    {
        throw new NotImplementedException();
    }

    public Task<UserViewModel?> GetByIdAsync(long id)
    {
        throw new NotImplementedException();
    }

    public Task<User?> GetIdAsync(long id)
    {
        throw new NotImplementedException();
    }

    public Task<IList<UserViewModel>> SearchAsync(string search, PaginationParams @params)
    {
        throw new NotImplementedException();
    }

    public Task<int> UpdateAsync(long id, User entity)
    {
        throw new NotImplementedException();
    }
}