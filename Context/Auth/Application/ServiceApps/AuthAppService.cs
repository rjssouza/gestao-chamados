using Auth.Application.Interfaces;
using Auth.Application.ViewModels.Account;
using Auth.Utils;
using Core.Application;
using Core.Domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.Security.Claims;

namespace Auth.Application.ServiceApps
{
    public class AuthAppService : ServiceApp, IAuthAppService
    {
        private readonly ILogger<AuthAppService> _logger;
        private readonly IUseCase<LoginInputModel, LoginViewModel> _loginUseCase;
        private readonly IUseCase<LogoutInputModel, LoggedOutViewModel> _logoutUseCase;
        private readonly IUseCase<RegisterViewModel, bool> _registerUseCase;
        private readonly ViewModelFactory _viewModelFactory;

        public AuthAppService(IServiceProvider serviceProvider)
            : base(serviceProvider)
        {
            _loginUseCase = serviceProvider.GetRequiredService<IUseCase<LoginInputModel, LoginViewModel>>();
            _logoutUseCase = serviceProvider.GetRequiredService<IUseCase<LogoutInputModel, LoggedOutViewModel>>();
            _registerUseCase = serviceProvider.GetRequiredService<IUseCase<RegisterViewModel, bool>>();
            _viewModelFactory = serviceProvider.GetRequiredService<ViewModelFactory>();
            _logger = serviceProvider.GetRequiredService<ILogger<AuthAppService>>();
        }

        public async Task<LoginViewModel> GetLoginViewModel(string returnUrl)
        {
            return await _viewModelFactory.BuildLoginViewModelAsync(returnUrl);
            //var currentUser = _httpContextAccessor.HttpContext?.User;
            //_logger.LogInformation("User com id {Name}", currentUser?.Identity?.Name);

            //var dominioUserName = currentUser?.Identity?.Name ?? $"{Environment.MachineName}\\developer";  //"AM\\EX-FMARCOS"
            //var nomeUsuario = dominioUserName.Split('\\').Last();
            //var dominio = dominioUserName.Split('\\').First();

            //var viewModel = new LoginInputModel()
            //{
            //    Password = nomeUsuario.ToLower(),
            //    Username = nomeUsuario,
            //    RememberLogin = true,
            //    ReturnUrl = returnUrl,
            //    Domain = dominio
            //};

            //var vm = await Login(viewModel);

            //return vm;
        }

        public async Task<LogoutViewModel> GetLogoutViewModel(string logoutId, ClaimsPrincipal user)
        {
            var vm = await _viewModelFactory.BuildLogoutViewModelAsync(logoutId, user);

            return vm;
        }

        public RegisterViewModel GetRegisterViewModel(string returnUrl)
        {
            var register = new RegisterViewModel
            {
                ReturnUrl = returnUrl
            };

            return register;
        }

        public async Task<LoginViewModel> Login(LoginInputModel loginViewModel)
        {
            return await _loginUseCase.Execute(loginViewModel);
        }

        public async Task<LoggedOutViewModel> Logout(LogoutInputModel model)
        {
            return await _logoutUseCase.Execute(model);
        }

        public async Task<bool> Register(RegisterViewModel applicationUserViewModel)
        {
            var result = await _registerUseCase.Execute(applicationUserViewModel);
            return result;
        }
    }
}