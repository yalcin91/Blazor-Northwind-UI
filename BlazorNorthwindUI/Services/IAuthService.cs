using BlazorNorthwindUI.Models;

using System.Threading.Tasks;

namespace BlazorNorthwindUI.Services
{
    public interface IAuthService
    {
        Task<LoginModel> Login(LoginModel loginModel);
        void Logout();
    }
}
