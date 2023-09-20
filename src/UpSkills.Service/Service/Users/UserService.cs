using UpSkills.Applications.Exceptions.Users;
using UpSkills.Applications.Utils;
using UpSkills.DataAccess.Interfaces.Users;
using UpSkills.DataAccess.ViewModels;
using UpSkills.Persistance.Dto.Users;
using UpSkills.Persistance.Helpers;
using UpSkills.Service.Interfaces.Commons;
using UpSkills.Service.Interfaces.Users;

namespace UpSkills.Service.Service.Users;

public class UserService : IUserService
{
    private IUserRepository _repository;
    private IFileService _fileservice;
    private IPaginator _paginator;

    public UserService(IUserRepository repository,
        IPaginator paginator, IFileService fileService)
    {
        this._repository = repository;
        this._fileservice = fileService;
        this._paginator = paginator;
    }
    public async Task<long> CountAsync() => await _repository.CountAsync();

    public async Task<bool> DeleteAsync(long userId)
    {
        var user = await _repository.GetIdAsync(userId);
        if (user is null) throw new UserNotFoundException();

        var deleteImage = await _fileservice.DeleteImageAsync(user.ImagePath);
        if (deleteImage == false) throw new FileNotFoundException();

        var result = await _repository.DeleteAsync(userId);

        return result > 0;
    }

    public async Task<IList<UserViewModel>> GetAllAsync(PaginationParams @params)
    {
        var user = await _repository.GetAllAsync(@params);
        var count = await _repository.CountAsync();
        _paginator.Paginate(count, @params);

        return user;
    }

    public async Task<UserViewModel> GetByIdAsync(long userId)
    {
        var user = await _repository.GetByIdAsync(userId);
        if (user is null) throw new UserNotFoundException();

        return user;
    }

    public async Task<IList<UserViewModel>> SearchAsync(string search, PaginationParams @params)
    {
        var user = await _repository.SearchAsync(search, @params);
        var count = await _repository.CountAsync();
        _paginator.Paginate(count, @params);

        return user;
    }

    public async Task<bool> UpdateAsync(long userId, UserUpdateDto dto)
    {
        var user = await _repository.GetIdAsync(userId);
        if (user is null) throw new UserNotFoundException();

        user.FirstName = dto.FirstName;
        user.LastName = dto.LastName;
        user.PhoneNumber = dto.PhoneNumber;
        user.BirthDate = dto.BirthDate;
        user.Description = dto.Description;
        if(dto.ImagePath is not null)
        {
            var delete = await _fileservice.DeleteImageAsync(user.ImagePath);
            string newImage = await _fileservice.UploadImageAsync(dto.ImagePath);
            user.ImagePath = newImage;
        }
        user.UpdatedAt = TimeHelpers.GetDateTime();
        var result = await _repository.UpdateAsync(userId, user);

        return result > 0;
    }
}