using UpSkills.Applications.Utils;
using UpSkills.DataAccess.Interfaces.Videos;
using UpSkills.DataAccess.ViewModels;
using UpSkills.Domain.Entities.Videos;
using UpSkills.Persistance.Dto.Videos;
using UpSkills.Persistance.Helpers;
using UpSkills.Service.Interfaces.Commons;
using UpSkills.Service.Interfaces.Videos;

namespace UpSkills.Service.Service.Videos;

public class VideoService : IVideoService
{
    private IVideoRepository _repository;
    private IFileService _fileservice;
    private IPaginator _paginator;

    public VideoService(IVideoRepository repository, IPaginator paginator,
        IFileService fileService)
    {
        this._repository = repository;
        this._fileservice = fileService;
        this._paginator = paginator;
    }

    public async Task<long> CountAsync() => await _repository.CountAsync();

    public async Task<bool> CreateAsync(VideoCreateDto dto)
    {
        var video = new Video();
        string file = await _fileservice.UploadVideoAsync(dto.VideoPath);
        string image = await _fileservice.UploadImageAsync(dto.ImagePath);
        video.ImagePath = image;
        video.VideoPath = file;
        video.CourseId = dto.CourseId;
        video.VideoDescription = dto.VideoDescription;
        video.CreatedAt = TimeHelpers.GetDateTime();
        var result = await _repository.CreateAsync(video);

        return result > 0;
    }

    public async Task<bool> DeleteAsync(long videoId)
    {
        var video = await _repository.GetByIdAsync(videoId);
        if (video is null) throw new FileNotFoundException();
        var file = await _fileservice.DeleteVideoAsync(video.VideoPath);
        var image = await _fileservice.DeleteImageAsync(video.ImagePath);
        var result = await _repository.DeleteAsync(videoId);

        return result > 0;
    }

    public async Task<IList<VideoViewModel>> GetAllAsync(PaginationParams @params)
    {
        var video = await _repository.GetAllAsync(@params);
        var count = await _repository.CountAsync();
        _paginator.Paginate(count, @params);

        return video;
    }

    public async Task<VideoViewModel?> GetByIdAsync(long videoId)
    {
        var video = await _repository.GetByIdAsync(videoId);
        if (video is null) throw new FileNotFoundException();

        return video;
    }

    public async Task<IList<VideoViewModel>> SearchAsync(string search, PaginationParams @params)
    {
        var video = await _repository.SearchAsync(search, @params);
        var count = await _repository.CountAsync();
        _paginator.Paginate(count, @params);

        return video;
    }
}