using UpSkills.DataAccess.ViewModels;
using UpSkills.Domain.Entities.Orders;

namespace UpSkills.DataAccess.Interfaces.Orders;

public interface IOrderRepository : IRepository<Order, OrderViewModel>
{
}