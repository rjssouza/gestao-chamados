using IdentityServer4;
using IdentityServer4.Models;
using Microsoft.Extensions.Configuration;

namespace Auth.Configuration
{
    internal static class Config
    {
        private static readonly string CHAMADOS_API_SCOPE = "ChamadosApi.full_access";
        private static readonly string ENVIAREMAIL_API_SCOPE = "EnviarEmailApi.full_access";
        private static readonly string PEDIDOS_API_SCOPE = "PedidosApi.full_access";
        private static readonly string HSE_API_SCOPE = "HSEApi.full_access";


        public static IEnumerable<ApiResource> Apis =>
            new ApiResource[]
            {
                new ApiResource("ChamadosApi")
                {
                    Scopes = new string[]{ CHAMADOS_API_SCOPE }
                },
                new ApiResource("EnviarEmailApi")
                {
                    Scopes = new string[]{ ENVIAREMAIL_API_SCOPE }
                },
                new ApiResource("PedidosApi")
                {
                    Scopes = new string[]{ PEDIDOS_API_SCOPE }
                },
                new ApiResource("HSEApi")
                {
                    Scopes = new string[]{ HSE_API_SCOPE }
                }
            };

        public static IEnumerable<ApiScope> ApiScope =>
            new ApiScope[]
            {
                new ApiScope(CHAMADOS_API_SCOPE),
                new ApiScope(PEDIDOS_API_SCOPE),
                new ApiScope(ENVIAREMAIL_API_SCOPE),
                new ApiScope(HSE_API_SCOPE)
            };

        public static IEnumerable<IdentityResource> Ids =>
            new IdentityResource[]
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                new IdentityResources.Email()
            };

        public static IEnumerable<Client> Clients(IConfiguration configuration) =>
            new Client[]
            {
                new Client
                {
                    ClientId = "angularUI",
                    ClientName = "Interface cliente angular",
                    AllowedGrantTypes = GrantTypes.Code,
                    IdentityProviderRestrictions = new List<string> { },
                    AllowedScopes = new List<string>
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.Email,
                        CHAMADOS_API_SCOPE,
                        PEDIDOS_API_SCOPE,
                        HSE_API_SCOPE
                    },
                    RedirectUris = configuration.GetSection("RedirectUris")?.Value?.Split(','),
                    PostLogoutRedirectUris = configuration.GetSection("PostLogoutRedirectUris")?.Value?.Split(','),
                    AllowedCorsOrigins = configuration.GetSection("AllowedCorsOrigins")?.Value?.Split(','),
                    AllowAccessTokensViaBrowser = true,
                    AccessTokenLifetime = 2592000,
                    AccessTokenType=AccessTokenType.Jwt,
                    RefreshTokenExpiration=TokenExpiration.Sliding,
                    SlidingRefreshTokenLifetime=2592000,
                    RefreshTokenUsage=TokenUsage.ReUse,
                    RequireConsent = false,
                    RequireClientSecret = false,
                    RequirePkce = true,
                    Enabled = true
                },
                new Client
                {
                    ClientId = "api",
                    ClientName = "Interface cliente api",
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    Enabled = true,
                    // secret for authentication
                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    },
                    AllowedScopes = new List<string>
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.Email,
                        ENVIAREMAIL_API_SCOPE
                    },
                }
            };
    }
}