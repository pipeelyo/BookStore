using BookStore.DAL.Models;

namespace BookStore.BLL.Interfaces
{
    public interface IAuthorService
    {
        Task<List<Author>> GetAllAsync();
        Task<Author> GetByIdAsync(int id);
        Task<Author> CreateAsync(Author author);
        Task DeleteAsync(int id);
        Task UpdateAsync(Author author);
    }
}
