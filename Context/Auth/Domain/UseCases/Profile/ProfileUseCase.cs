using Auth.Utils;
using Core.Application.Seguranca;
using Core.Application.UseCases;
using Core.Domain.Interfaces;
using Core.Extensions;
using IdentityServer4.Models;
using Microsoft.AspNetCore.Identity;
using Security.Domain.Entities;
using System.DirectoryServices;
using System.Security.Claims;

namespace Auth.Domain.UseCases
{
    public class ProfileUseCase : UseCase<ProfileDataRequestContext, List<Claim>>, IUseCase<ProfileDataRequestContext, List<Claim>>
    {
        private readonly AdUserFactory _adUserFactory;
        private readonly UserManager<ApplicationUser> _userManager;

        public ProfileUseCase(IServiceProvider serviceProvider)
            : base(serviceProvider)
        {
            _userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            _adUserFactory = serviceProvider.GetRequiredService<AdUserFactory>();
        }

        protected override async Task<List<Claim>> ExecuteInternal(ProfileDataRequestContext context)
        {
            //>Processing
            var user = await _userManager.GetUserAsync(context.Subject) ?? throw new ArgumentNullException(context.Subject.GetType().Name);
            var userInfo = _adUserFactory.ObterDadosUsuario(user.UserName);
            var email = string.IsNullOrWhiteSpace(GetProfileValue(AdUserFactory.P_EMAIL, userInfo)) ? GetProfileValue(AdUserFactory.P_USERPRINCIPALNAME, userInfo) : GetProfileValue(AdUserFactory.P_EMAIL, userInfo);

            var roles = await _userManager.GetRolesAsync(user);
            var currentClaims = await _userManager.GetClaimsAsync(user);

            var claims = new List<Claim>
            {
                new Claim(UserInfo.DOMAIN_CLAIM, user.Domain ?? string.Empty),
                new Claim(UserInfo.PHOTO, string.Empty),
                new Claim(UserInfo.TITLE, GetProfileValue(AdUserFactory.P_TITLE, userInfo)),
                new Claim(UserInfo.USERNAME, user.UserName ?? string.Empty),
                new Claim(ClaimTypes.Sid, user.Id ?? string.Empty),
                new Claim(ClaimTypes.Name, GetProfileValue(AdUserFactory.P_NOME, userInfo) ?? user.UserName ?? string.Empty),
                new Claim(ClaimTypes.Email, email),
                new Claim(ClaimTypes.Surname, GetProfileValue(AdUserFactory.P_SOBRENOME, userInfo)),
                new Claim(ClaimTypes.PostalCode, GetProfileValue(AdUserFactory.P_POSTALCODE, userInfo)),
                new Claim(ClaimTypes.Country, GetProfileValue(AdUserFactory.P_COUNTRY, userInfo)),
                new Claim(ClaimTypes.MobilePhone, GetProfileValue(AdUserFactory.P_PHONE, userInfo)),
                new Claim(ClaimTypes.Locality, GetProfileValue(AdUserFactory.P_LOCALITY, userInfo)),
                new Claim(ClaimTypes.StreetAddress, GetProfileValue(AdUserFactory.P_LOCALITY, userInfo)),
                new Claim(ClaimTypes.StateOrProvince, GetProfileValue(AdUserFactory.P_STATE, userInfo)),
                new Claim("Roles", string.Join(",", roles))
            };

            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            claims.AddRange(currentClaims);

            return claims;
        }

        private static string GetProfileValue(string profileName, SearchResult? userInfo)
        {
            var property = userInfo?.Properties[profileName];
            if (property == null || property.Count <= 0)
                return string.Empty;

            return property[0].ToString() ?? string.Empty;
        }
    }
}