﻿using UpSkills.Applications.Utils;
using UpSkills.DataAccess.ViewModels;
using UpSkills.Persistance.Dto.Orders;

namespace UpSkills.Service.Interfaces.Orders;

public interface IOrderService
{
    public Task<bool> CreateAsync(OrderCreateDto dto);
    public Task<bool> DeleteAsync(long orderId);
    public Task<OrderViewModel?> GetByIdAsync(long orderId);
    public Task<IList<OrderViewModel>> GetAllAsync(PaginationParams @params);
    public Task<long> CountAsync();
}