using UpSkills.Applications.Utils;
using UpSkills.DataAccess.ViewModels;
using UpSkills.Persistance.Dto.Videos;

namespace UpSkills.Service.Interfaces.Videos;

public interface IVideoService
{
    public Task<bool> CreateAsync(VideoCreateDto dto);
    public Task<bool> DeleteAsync(long videoId);
    public Task<VideoViewModel?> GetByIdAsync(long videoId);
    public Task<IList<VideoViewModel?>> SearchAsync(string search, PaginationParams @params);
    public Task<IList<VideoViewModel>> GetAllAsync(PaginationParams @params);
    public Task<long> CountAsync();
}