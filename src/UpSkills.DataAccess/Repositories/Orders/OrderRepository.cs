using UpSkills.Applications.Utils;
using UpSkills.DataAccess.Interfaces.Orders;
using UpSkills.DataAccess.ViewModels;
using UpSkills.Domain.Entities.Orders;

namespace UpSkills.DataAccess.Repositories.Orders;

public class OrderRepository : IOrderRepository
{
    public Task<long> CountAsync()
    {
        throw new NotImplementedException();
    }

    public Task<int> CreateAsync(Order entity)
    {
        throw new NotImplementedException();
    }

    public Task<int> DeleteAsync(long id)
    {
        throw new NotImplementedException();
    }

    public Task<IList<OrderViewModel>> GetAllAsync(PaginationParams @params)
    {
        throw new NotImplementedException();
    }

    public Task<OrderViewModel> GetByIdAsync(long id)
    {
        throw new NotImplementedException();
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