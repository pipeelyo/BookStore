using BookStore.DAL.Models;

namespace BookStore.BLL.Interfaces
{
    public interface IAuthorizacionService
    {
        Task<AutorizacionResponse> ReturnToken(AutorizacionRequest authorization);
    }
}
