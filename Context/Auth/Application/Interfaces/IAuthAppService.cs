using Auth.Application.ViewModels.Account;
using System.Security.Claims;

namespace Auth.Application.Interfaces
{
    public interface IAuthAppService : IDisposable
    {
        Task<LoginViewModel> GetLoginViewModel(string returnUrl);

        Task<LogoutViewModel> GetLogoutViewModel(string logoutId, ClaimsPrincipal user);

        RegisterViewModel GetRegisterViewModel(string returnUrl);

        Task<LoginViewModel> Login(LoginInputModel loginViewModel);

        Task<LoggedOutViewModel> Logout(LogoutInputModel model);

        Task<bool> Register(RegisterViewModel applicationUserViewModel);
    }
}