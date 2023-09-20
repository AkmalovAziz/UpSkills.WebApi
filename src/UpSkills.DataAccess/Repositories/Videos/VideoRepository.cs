using Dapper;
using UpSkills.Applications.Utils;
using UpSkills.DataAccess.Interfaces.Videos;
using UpSkills.DataAccess.ViewModels;
using UpSkills.Domain.Entities.Videos;

namespace UpSkills.DataAccess.Repositories.Videos;

public class VideoRepository : BaseRepository, IVideoRepository
{
    public async Task<long> CountAsync()
    {
        try
        {
            await _connection.OpenAsync();
            
            string query = "SELECT COUNT(*) FROM videos";

            var result = await _connection.QuerySingleAsync<long>(query);

            return result;
        }
        catch 
        {
            return 0;
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public async Task<int> CreateAsync(Video entity)
    {
        try
        {
            await _connection.OpenAsync();
            string query = "INSERT INTO public.videos(course_id, image_path, video_path, video_descriptions, created_at) " +
                "VALUES (@CourseId, @ImagePath, @VideoPath, @VideoDescription, @CreatedAt);";

            var result = await _connection.ExecuteAsync(query, entity);

            return result;
        }
        catch
        {
            return 0;
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public async Task<long> DeleteAsync(long id)
    {
        try
        {
            await _connection.OpenAsync();

            string query = "DELETE FROM videos WHERE id = @Id OR course_id = @Id";

            var result = await _connection.ExecuteAsync(query, new {Id = id});

            return result;
        }
        catch
        {
            return 0;
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public async Task<IList<VideoViewModel>> GetAllAsync(PaginationParams @params)
    {
        try
        {
            await _connection.OpenAsync();
            string query = $"SELECT videos.course_id, videos.image_path, videos.video_path, videos.id, courses.course_name," +
                $"videos.created_at FROM videos JOIN courses ON courses.id = videos.course_id ORDER BY videos.id DESC " +
                    $"OFFSET {@params.SkipCount()} LIMIT {@params.PageSize}";

            var result = (await _connection.QueryAsync<VideoViewModel>(query)).ToList();

            return result;
        }
        catch
        {
            return new List<VideoViewModel>();
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public async Task<VideoViewModel?> GetByIdAsync(long id)
    {
        try
        {
            await _connection.OpenAsync();

            string query = "SELECT videos.course_id, videos.image_path, videos.video_path, " +
                "courses.course_name, videos.id, videos.created_at FROM videos JOIN courses ON courses.id = videos.course_id " +
                    "WHERE videos.id = @Id";

            var result = await _connection.QuerySingleAsync<VideoViewModel>(query, new {Id = id});

            return result;
        }
        catch
        {
            return null;
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public async Task<Video?> GetIdAsync(long id)
    {
        try
        {
            await _connection.OpenAsync();

            string query = "SELECT * FROM videos WHERE id = @Id";

            var result = await _connection.QuerySingleAsync<Video>(query, new { Id = id });

            return result;
        }
        catch
        {
            return null;
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public async Task<IList<VideoViewModel>> SearchAsync(string search, PaginationParams @params)
    {
        try
        {
            await _connection.OpenAsync();
            string query = $"SELECT videos.course_id, videos.image_path, videos.video_path, " +
                $"courses.course_name, videos.id, videos.created_at FROM videos JOIN courses ON courses.id = videos.course_id " +
                    $"WHERE courses.course_name ILIKE '{search}%' OR courses.course_name ILIKE '%{search}%' OFFSET {@params.SkipCount()} " +
                        $"LIMIT {@params.PageSize}";

            var result = (await _connection.QueryAsync<VideoViewModel>(query)).ToList();

            return result;
        }
        catch
        {
            return new List<VideoViewModel>();
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public Task<int> UpdateAsync(long id, Video entity)
    {
        throw new NotImplementedException();
    }
}