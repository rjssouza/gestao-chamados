using Core.Domain.Interfaces;
using IdentityServer4.Models;
using IdentityServer4.Services;
using System.Security.Claims;

namespace Auth.Application.ServiceApps
{
    public class ProfileServiceApp : IProfileService
    {
        private readonly IUseCase<IsActiveContext, bool> _userActiveUseCase;
        private readonly IUseCase<ProfileDataRequestContext, List<Claim>> _userClaimProfile;

        public ProfileServiceApp(IUseCase<ProfileDataRequestContext, List<Claim>> userClaimProfile,
            IUseCase<IsActiveContext, bool> userActiveUseCase)
        {
            _userClaimProfile = userClaimProfile;
            _userActiveUseCase = userActiveUseCase;
        }

        public async Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            var claims = await _userClaimProfile.Execute(context);
            context.IssuedClaims = claims;
        }

        public async Task IsActiveAsync(IsActiveContext context)
        {
            context.IsActive = await _userActiveUseCase.Execute(context);
        }
    }
}