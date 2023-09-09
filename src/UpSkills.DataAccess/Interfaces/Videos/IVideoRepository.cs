using UpSkills.DataAccess.Commons.Interfaces;
using UpSkills.DataAccess.ViewModels;
using UpSkills.Domain.Entities.Videos;

namespace UpSkills.DataAccess.Interfaces.Videos;

public interface IVideoRepository : IRepository<Video, VideoViewModel>, ISearch<VideoViewModel>
{
}