using Core.Application.UseCases;
using Core.Domain.Interfaces;
using Core.Extensions;
using IdentityServer4.Models;
using Microsoft.AspNetCore.Identity;
using Security.Domain.Entities;

namespace Auth.Domain.UseCases
{
    public class UserActiveUseCase : UseCase<IsActiveContext, bool>, IUseCase<IsActiveContext, bool>
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public UserActiveUseCase(IServiceProvider serviceProvider)
            : base(serviceProvider)
        {
            _userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
        }

        protected override async Task<bool> ExecuteInternal(IsActiveContext context)
        {
            //>Processing
            var user = await _userManager.GetUserAsync(context.Subject);
            var blockedUser = user == null || await _userManager.IsLockedOutAsync(user);

            return (user != null) && !blockedUser;
        }
    }
}