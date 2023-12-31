﻿using UpSkills.Applications.Utils;

namespace UpSkills.DataAccess.Interfaces
{
    public interface IRepository<TEntity, TViewModel>
    {
        public Task<int> CreateAsync(TEntity entity);
        public Task<int> UpdateAsync(long id, TEntity entity);
        public Task<long> DeleteAsync(long id);
        public Task<IList<TViewModel>> GetAllAsync(PaginationParams @params);
        public Task<TViewModel> GetByIdAsync(long id);
        public Task<long> CountAsync();
        public Task<TEntity> GetIdAsync(long id);
    }
}