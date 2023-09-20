using UpSkills.Applications.Utils;
using UpSkills.DataAccess.ViewModels;
using UpSkills.Persistance.Dto.Users;

namespace UpSkills.Service.Interfaces.Users;

public interface IUserService 
{
    public Task<bool> UpdateAsync(long userId, UserUpdateDto dto);
    public Task<bool> DeleteAsync(long userId);
    public Task<IList<UserViewModel>> GetAllAsync(PaginationParams @params);
    public Task<UserViewModel> GetByIdAsync(long userId);
    public Task<IList<UserViewModel>> SearchAsync(string search, PaginationParams @params);
    public Task<long> CountAsync();
}