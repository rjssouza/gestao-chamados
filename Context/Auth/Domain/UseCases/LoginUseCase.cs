using Auth.Application.ViewModels.Account;
using Auth.Utils;
using Core.Application.UseCases;
using Core.Domain.Interfaces;
using Core.Extensions;
using Microsoft.AspNetCore.Identity;
using Security.Domain.Entities;

namespace Auth.Domain.UseCases
{
    public class LoginUseCase : UseCase<LoginInputModel, LoginViewModel>, IUseCase<LoginInputModel, LoginViewModel>
    {
        private readonly IUseCase<RegisterViewModel, bool> _registerUseCase;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ViewModelFactory _viewModelFactory;

        public LoginUseCase(IServiceProvider serviceProvider)
            : base(serviceProvider)
        {
            _viewModelFactory = serviceProvider.GetRequiredService<ViewModelFactory>();
            _signInManager = serviceProvider.GetRequiredService<SignInManager<ApplicationUser>>();
            _registerUseCase = serviceProvider.GetRequiredService<IUseCase<RegisterViewModel, bool>>();
        }

        protected override async Task<LoginViewModel> ExecuteInternal(LoginInputModel entry)
        {
            var result = await _signInManager.PasswordSignInAsync(entry.Username, entry.Password, false, false);
            if (!result.Succeeded)
            {
                await _registerUseCase.Execute(this._mapper.Map<RegisterViewModel>(entry));
                return await ExecuteInternal(entry);
            }

            var loginViewModel = await BuildLoginViewModelAsync(entry);

            return loginViewModel;
        }

        private async Task<LoginViewModel> BuildLoginViewModelAsync(LoginInputModel model)
        {
            var vm = await _viewModelFactory.BuildLoginViewModelAsync(model.ReturnUrl);
            vm.Username = model.Username;
            vm.RememberLogin = model.RememberLogin;
            vm.ReturnUrl = model.ReturnUrl ?? "/diagnostics";

            return vm;
        }
    }
}