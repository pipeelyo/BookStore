﻿using BookStore.DAL.Models;

namespace BookStore.BLL.Interfaces
{
    public interface IUserService
    {
        Task<List<User>> GetAllAsync();
        Task<User> GetByIdAsync(int id);
        Task<User> CreateAsync(User user);
        Task DeleteAsync(int id);
        Task UpdateAsync(User user);
    }
}
