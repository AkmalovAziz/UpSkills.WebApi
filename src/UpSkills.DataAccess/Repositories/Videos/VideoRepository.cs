using UpSkills.Applications.Utils;
using UpSkills.DataAccess.Interfaces.Videos;
using UpSkills.DataAccess.ViewModels;
using UpSkills.Domain.Entities.Videos;

namespace UpSkills.DataAccess.Repositories.Videos;

public class VideoRepository : IVideoRepository
{
    public Task<long> CountAsync()
    {
        throw new NotImplementedException();
    }

    public Task<int> CreateAsync(Video entity)
    {
        throw new NotImplementedException();
    }

    public Task<int> DeleteAsync(long id)
    {
        throw new NotImplementedException();
    }

    public Task<IList<VideoViewModel>> GetAllAsync(PaginationParams @params)
    {
        throw new NotImplementedException();
    }

    public Task<VideoViewModel> GetByIdAsync(long id)
    {
        throw new NotImplementedException();
    }

    public Task<Video> GetIdAsync(long id)
    {
        throw new NotImplementedException();
    }

    public Task<IList<VideoViewModel>> SearchAsync(string search, PaginationParams @params)
    {
        throw new NotImplementedException();
    }

    public Task<int> UpdateAsync(long id, Video entity)
    {
        throw new NotImplementedException();
    }
}