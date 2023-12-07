using Auth.Application.ViewModels.Account;
using Core.Application.Seguranca;
using Core.Application.UseCases;
using Core.Domain.Interfaces;
using Core.Extensions;
using Microsoft.AspNetCore.Identity;
using Security.Domain.Entities;

namespace Auth.Domain.UseCases
{
    public class RegisterUseCase : UseCase<RegisterViewModel, bool>, IUseCase<RegisterViewModel, bool>
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public RegisterUseCase(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            _userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            _roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
        }

        protected override async Task<bool> ExecuteInternal(RegisterViewModel entry)
        {
            var applicationUser = this._mapper.Map<ApplicationUser>(entry);
            applicationUser.Id = Guid.NewGuid().ToString();
            var result = await _userManager.CreateAsync(applicationUser, entry.Password);
            if (result.Succeeded)
            {
                await AddRole(applicationUser, UserInfo.ROLE_COLABORADOR);
            }
            else
            {
                AddError("User", string.Join("|", result.Errors.Select(t => t.Description)));
                IsValid();
            }

            return result.Succeeded;
        }

        private async Task AddRole(ApplicationUser user, string roleName)
        {
            var role = await _roleManager.FindByNameAsync(roleName);
            if (role == null)
                await _roleManager.CreateAsync(new IdentityRole(roleName));

            await _userManager.AddToRoleAsync(user, roleName);
        }
    }
}