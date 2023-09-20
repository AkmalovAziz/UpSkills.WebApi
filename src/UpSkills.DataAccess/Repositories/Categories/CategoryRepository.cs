using Dapper;
using UpSkills.Applications.Utils;
using UpSkills.DataAccess.Interfaces.Categories;
using UpSkills.Domain.Entities.Categories;
using static Dapper.SqlMapper;

namespace UpSkills.DataAccess.Repositories.Categories;

public class CategoryRepository : BaseRepository, ICategoryRepository
{
    public async Task<long> CountAsync()
    {
        try
        {
            await _connection.OpenAsync();

            string query = "SELECT COUNT(*) FROM categories";

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

    public async Task<int> CreateAsync(Category entity)
    {
        try
        {
            await _connection.OpenAsync();
            string query = "INSERT INTO public.categories(category_name, description, created_at, updated_at, image_path)" +
                "VALUES (@CategoryName, @Description, @CreatedAt, @UpdatedAt, @ImagePath);";

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

            string query = $"DELETE FROM categories WHERE id=@Id;";

            var result = await _connection.ExecuteAsync(query, new { Id = id });

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

    public async Task<IList<Category>> GetAllAsync(PaginationParams @params)
    {
        try
        {
            await _connection.OpenAsync();
            string query = $"SELECT * FROM categories ORDER BY id DESC OFFSET {@params.SkipCount()} " +
                $"LIMIT {@params.PageSize}";

            var result = (await _connection.QueryAsync<Category>(query)).ToList();

            return result;
        }
        catch
        {
            return new List<Category>();
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public async Task<Category?> GetByIdAsync(long id)
    {
        throw new NotImplementedException();
    }

    public async Task<Category?> GetIdAsync(long id)
    {
        try
        {
            await _connection.OpenAsync();

            string query = "SELECT * FROM categories WHERE id = @Id;";

            var result = await _connection.QuerySingleAsync<Category>(query, new { Id = id });

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

    public async Task<IList<Category>> SearchAsync(string search, PaginationParams @params)
    {
        try
        {
            await _connection.OpenAsync();
            string query = $"SELECT * FROM categories WHERE category_name ILIKE '{search}%' OR category_name ILIKE " +
                $"'%{search}%' OFFSET {@params.SkipCount()} LIMIT {@params.PageSize}";

            var result = (await _connection.QueryAsync<Category>(query)).ToList();

            return result;
        }
        catch
        {
            return new List<Category>();
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public async Task<int> UpdateAsync(long id, Category entity)
    {
        try
        {
            await _connection.OpenAsync();
            string query = $"UPDATE public.categories SET category_name=@CategoryName, description=@Description, created_at=@CreatedAt, " +
                $"updated_at=@UpdatedAt, image_path=@ImagePath WHERE id = {id};";

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