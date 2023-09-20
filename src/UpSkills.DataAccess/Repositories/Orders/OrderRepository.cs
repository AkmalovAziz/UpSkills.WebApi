using Dapper;
using UpSkills.Applications.Utils;
using UpSkills.DataAccess.Interfaces.Orders;
using UpSkills.DataAccess.ViewModels;
using UpSkills.Domain.Entities.Orders;

namespace UpSkills.DataAccess.Repositories.Orders;

public class OrderRepository : BaseRepository, IOrderRepository
{
    public async Task<long> CountAsync()
    {
        try
        {
            await _connection.OpenAsync();
            
            string query = "SELECT COUNT(*) FROM orders;";

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

    public async Task<int> CreateAsync(Order entity)
    {
        try
        {
            await _connection.OpenAsync();

            string query = "INSERT INTO orders(course_id, user_id, created_at) VALUES (@CourseId, @UserId, @CreatedAt);";

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

            string query = "DELETE FROM orders WHERE id = @Id;";

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

    public Task<IList<OrderViewModel>> GetAllAsync(PaginationParams @params)
    {
        throw new NotImplementedException();
    }

    public async Task<OrderViewModel?> GetByIdAsync(long id)
    {
        try
        {
            await _connection.OpenAsync();

            string query = "SELECT * FROM orders JOIN courses ON orders.course_id = courses.id JOIN users ON " +
                "orders.user_id = users.id WHERE orders.id = @Id;";

            var result = await _connection.QuerySingleOrDefaultAsync<OrderViewModel>(query, new {Id = id});

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

    public Task<Order> GetIdAsync(long id)
    {
        throw new NotImplementedException();
    }

    public Task<int> UpdateAsync(long id, Order entity)
    {
        throw new NotImplementedException();
    }
}