using BookStore.DAL.Models;

namespace BookStore.BLL.Interfaces
{
    public interface IBookService
    {
        Task<List<Book>> GetAllAsync();
        Task<Book> GetByIdAsync(int id);
        Task<Book> CreateAsync(Book book);
        Task DeleteAsync(int id);
        Task UpdateAsync(Book book);
    }
}
