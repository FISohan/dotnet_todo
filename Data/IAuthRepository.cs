using System.Threading.Tasks;
using dotnet_todo.Model;

namespace dotnet_todo.Data
{
    public interface IAuthRepository
    {
        Task<ServiceResponse<int>> Register(User user, string Password);
        Task<ServiceResponse<string>> Loging(string username, string Password);
        Task<bool> UserExits(string username);
    }
}