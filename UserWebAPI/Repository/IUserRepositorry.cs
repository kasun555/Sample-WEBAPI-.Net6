using UserWebAPI.Models;
using System.Threading;
using System.Linq;
using UserWebAPI.ViewModels;
namespace UserWebAPI.Repository

{
    public interface IUserRepositorry
    {
        Task<List<tbUserViewModels>> GetUsers();
        Task<tbUserViewModels> GetUsers(int UserID);

        Task<bool> CheckUserExistByEmail(string email);

        Task<int> AddUsers(tbUserViewModels User);

        Task<int> DeleteUsers(int UserID);

        Task<int> UpdateUsers(int UserID, tbUserViewModels User);
    }
}
