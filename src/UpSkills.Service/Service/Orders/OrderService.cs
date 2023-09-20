using UpSkills.Applications.Exceptions.Orders;
using UpSkills.Applications.Exceptions.Users;
using UpSkills.DataAccess.Interfaces.Orders;
using UpSkills.DataAccess.ViewModels;
using UpSkills.Domain.Entities.Orders;
using UpSkills.Persistance.Dto.Orders;
using UpSkills.Persistance.Helpers;
using UpSkills.Service.Interfaces.Commons;
using UpSkills.Service.Interfaces.Orders;

namespace UpSkills.Service.Service.Orders;

public class OrderService : IOrderService
{
    private IOrderRepository _repository;
    private IIdentityService _identity;

    public OrderService(IOrderRepository repository, IIdentityService identityService)
    {
        this._repository = repository;
        this._identity = identityService;
    }
    public async Task<long> CountAsync() => await _repository.CountAsync();

    public async Task<bool> CreateAsync(OrderCreateDto dto)
    {

        var order = new Order();
        order.UserId = _identity.UserId;
        if (order.UserId == 0) throw new UnauthorizedAccessException();
        order.CourseId = dto.CourseId;
        order.CreatedAt = TimeHelpers.GetDateTime();
        var result = await _repository.CreateAsync(order);

        return result > 0;
    }

    public async Task<bool> DeleteAsync(long orderId)
    {
        var order = await _repository.GetByIdAsync(orderId);
        if (order is null) throw new OrderNotFoundException();

        if (order.UserId != _identity.UserId) throw new UnauthorizedAccessException();

        var result = await _repository.DeleteAsync(orderId);

        return result > 0;
    }

    public async Task<OrderViewModel?> GetByIdAsync(long orderId)
    {
        var order = await _repository.GetByIdAsync(orderId);
        if (order is null) throw new OrderNotFoundException();

        return order;
    }
}