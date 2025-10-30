﻿
using Core.Entities;

namespace Application.Interfaces.IRepositories
{
    public interface ICategoryRepository 
    {
        Task<List<Category>?> GetAllAsync();
        Task<Category> GetByIdAsync(Guid id);
        Task Update(Category entity);
        Task<Category> AddAsync(Category entity);
        Task DeleteAsync(Guid id);
    }
}
