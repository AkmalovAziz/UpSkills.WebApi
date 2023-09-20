using Dapper;
using UpSkills.Applications.Utils;
using UpSkills.DataAccess.Interfaces.Users;
using UpSkills.DataAccess.ViewModels;
using UpSkills.Domain.Entities.Users;

namespace UpSkills.DataAccess.Repositories.Users;

public class UserRepository : BaseRepository, IUserRepository
{
    public async Task<long> CountAsync()
    {
        try
        {
            await _connection.OpenAsync();
            
            string query = "SELECT COUNT(*) FROM users;";

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

    public async Task<int> CreateAsync(User entity)
    {
        try
        {
            await _connection.OpenAsync();
            string query = "INSERT INTO public.users(first_name, last_name, phone_number, image_path, email, " +
                "descriptions, birth_date, password_hash, salt, created_at, updated_at, amount, status) VALUES (@FirstName, " +
                    "@LastName, @PhoneNumber, @ImagePath, @Email, @Description, @BirthDate, @Password, @Salt, " +
                        "@CreatedAt, @UpdatedAt, @Amount, @Status);";

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

            string query = "DELETE FROM users WHERE id = @Id;";

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

    public async Task<IList<UserViewModel>> GetAllAsync(PaginationParams @params)
    {
        try
        {
            await _connection.OpenAsync();

            string query = $"SELECT * FROM users ORDER BY id OFFSET {@params.SkipCount()} LIMIT {@params.PageSize};";

            var result = (await _connection.QueryAsync<UserViewModel>(query)).ToList();

            return result;
        }
        catch
        {
            return new List<UserViewModel>();
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public async Task<User?> GetByEmailAsync(string email)
    {
        try
        {
            await _connection.OpenAsync();
            
            string query = "SELECT * FROM users WHERE email = @Email;";

            var result = await _connection.QuerySingleOrDefaultAsync<User>(query, new { Email = email });

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

    public async Task<UserViewModel?> GetByIdAsync(long id)
    {
        try
        {
            await _connection.OpenAsync();

            string query = "SELECT * FROM users WHERE id = @Id;";

            var result = await _connection.QuerySingleAsync<UserViewModel>(query, new {Id = id});

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

    public async Task<User?> GetIdAsync(long id)
    {
        try
        {
            await _connection.OpenAsync();

            string query = "SELECT * FROM users WHERE id = @Id;";

            var result = await _connection.QuerySingleAsync<User>(query, new { Id = id });

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

    public async Task<IList<UserViewModel>> SearchAsync(string search, PaginationParams @params)
    {
        try
        {
            await _connection.OpenAsync();

            string query = $"SELECT * FROM users WHERE first_name ILIKE '{search}%' OR last_name ILIKE '{search}%'";

            var result = (await _connection.QueryAsync<UserViewModel>(query)).ToList();

            return result;
        }
        catch
        {
            return new List<UserViewModel>();
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public async Task<int> UpdateAsync(long id, User entity)
    {
        try
        {
            await _connection.OpenAsync();

            string query = $"UPDATE public.users SET first_name=@FirstName, last_name=@LastName, phone_number=@PhoneNumber," +
                $"image_path=@ImagePath, email=@Email, descriptions=@Description, birth_date=@BirthDate, created_at=@CreatedAt, updated_at=@UpdatedAt " +
                    $"WHERE id = {id};";

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