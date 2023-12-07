using Auth.Application.ViewModels.Account;
using Core.Application.UseCases;
using Core.Domain.Interfaces;
using Core.Extensions;
using IdentityServer4.Services;
using Microsoft.AspNetCore.Identity;
using Security.Domain.Entities;

namespace Auth.Domain.UseCases
{
    public class LogoutUseCase : UseCase<LogoutInputModel, LoggedOutViewModel>, IUseCase<LogoutInputModel, LoggedOutViewModel>
    {
        private readonly IIdentityServerInteractionService _interaction;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public LogoutUseCase(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            _interaction = serviceProvider.GetRequiredService<IIdentityServerInteractionService>();
            _signInManager = serviceProvider.GetRequiredService<SignInManager<ApplicationUser>>();
        }

        protected override async Task<LoggedOutViewModel> ExecuteInternal(LogoutInputModel entry)
        {
            await _signInManager.SignOutAsync();
            await _interaction.GetLogoutContextAsync(entry.LogoutId);
            var vm = await BuildLoggedOutViewModelAsync(entry.LogoutId);

            return vm;
        }

        private async Task<LoggedOutViewModel> BuildLoggedOutViewModelAsync(string logoutId)
        {
            // get context information (client name, post logout redirect URI and iframe for federated signout)
            var logout = await _interaction.GetLogoutContextAsync(logoutId);

            var vm = new LoggedOutViewModel
            {
                AutomaticRedirectAfterSignOut = AccountOptions.AutomaticRedirectAfterSignOut,
                PostLogoutRedirectUri = logout?.PostLogoutRedirectUri,
                ClientName = string.IsNullOrEmpty(logout?.ClientName) ? logout?.ClientId : logout?.ClientName,
                SignOutIframeUrl = logout?.SignOutIFrameUrl,
                LogoutId = logoutId
            };

            return vm;
        }
    }
}