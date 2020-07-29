using DL.Responses;
using System.Threading.Tasks;

namespace DL.Services
{
    public interface IAuthService
    {
        Task<LoginResponse> Login(string userName, string password, bool lockoutOnFailure = false);
        Task Register();
    }
}