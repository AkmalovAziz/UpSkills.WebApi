using Dapper;
using UpSkills.Applications.Utils;
using UpSkills.DataAccess.Interfaces.Courses;
using UpSkills.DataAccess.ViewModels;
using UpSkills.Domain.Entities.Courses;

namespace UpSkills.DataAccess.Repositories.Courses;

public class CourseRepository : BaseRepository, ICoursRepository
{
    public async Task<long> CountAsync()
    {
        try
        {
            await _connection.OpenAsync();
            
            string query = "SELECT COUNT(*) FROM courses;";

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

    public async Task<int> CreateAsync(Course entity)
    {
        try
        {
            await _connection.OpenAsync();

            string query = "INSERT INTO public.courses(category_id, course_name, price_per_month, description, image_path, " +
                "created_at, updated_at) VALUES (@CategoryId, @CourseName, @PricePerMonth, @Description, @ImagePath, @CreatedAt, " +
                    "@UpdatedAt);";

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

    public async Task<int> DeleteAsync(long id)
    {
        try
        {
            await _connection.OpenAsync();

            string query = "DELETE FROM courses WHERE id = @Id;";

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

    public async Task<IList<CourseViewModel>> GetAllAsync(PaginationParams @params)
    {
        try
        {
            await _connection.OpenAsync();

            string query = $"SELECT * FROM courses JOIN categories ON courses.category_id = categories.id ORDER BY " +
                $"courses.id DESC OFFSET {@params.SkipCount()} LIMIT {@params.PageSize};";

            var result = (await _connection.QueryAsync<CourseViewModel>(query)).ToList();

            return result;
        }
        catch
        {
            return new List<CourseViewModel>();
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public async Task<CourseViewModel?> GetByIdAsync(long id)
    {
        try
        {
            await _connection.OpenAsync();

            string query = "SELECT * FROM courses JOIN categories ON courses.category_id = categories.id WHERE courses.id = @Id";

            var result = await _connection.QuerySingleOrDefaultAsync<CourseViewModel>(query, new {Id = id});

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

    public async Task<Course?> GetIdAsync(long id)
    {
        try
        {
            await _connection.OpenAsync();

            string query = "SELECT * FROM courses WHERE id = @Id";

            var result = await _connection.QuerySingleAsync<Course>(query, new { Id = id });

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

    public async Task<IList<CourseViewModel>> SearchAsync(string search, PaginationParams @params)
    {
        try
        {
            await _connection.OpenAsync();

            string query = $"SELECT * FROM courses JOIN categories ON courses.category_id = categories.id WHERE " +
                $"courses.course_name ILIKE '{search}%' OR courses.course_name ILIKE '%{search}%'";

            var result = (await _connection.QueryAsync<CourseViewModel>(query)).ToList();

            return result;
        }
        catch
        {
            return new List<CourseViewModel>();
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public async Task<int> UpdateAsync(long id, Course entity)
    {
        try
        {
            await _connection.OpenAsync();

            string query = $"UPDATE public.courses SET course_name=@CourseName, price_per_month=@PricePerMonth, description=@Description, " +
                $"image_path=@ImagePath, created_at=@CreatedAt, updated_at=@UpdatedAt WHERE id = {id};";

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
}