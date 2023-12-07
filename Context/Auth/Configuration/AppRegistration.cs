using Auth.Application.AutoMapper.Account;
using Auth.Application.Interfaces;
using Auth.Application.ServiceApps;
using Auth.Configuration;
using Auth.Data.Context;
using Auth.Utils;
using AutoMapper;
using Core.Data.Repositories;
using Core.Domain.Interfaces;
using Core.Domain.Interfaces.Repositories;
using Core.Utils.Extension;
using IdentityServer4.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Security.Domain.Entities;

namespace Chamados.Configuration
{
    public static class AppRegistration
    {
        public static IServiceCollection AddAuth(this IServiceCollection services, IConfiguration configuration)
        {
            var mapper = GetMapper();
            services.AddSingleton(mapper);

            services.AddEntity()
                    .AddUtils()
                    .AddHttpClient()
                    .AddHttpContextAccessor()
                    .AddInfrastructure(configuration);

            services.AddTransient<IAuthAppService, AuthAppService>();
            services.AddTransient<IProfileService, ProfileServiceApp>();
            services.AddTransient<IUserPhotoAppService, UserPhotoAppService>();
            services.RegisterAllTypes(typeof(IUseCase<,>), new[] { typeof(AppRegistration).Assembly });
            services.AddSingleton<ICorsPolicyService, CorsPolicyService>();
            services.AddSingleton<ICorsPolicyService>((container) => {
                var logger = container.GetRequiredService<ILogger<DefaultCorsPolicyService>>();
                return new DefaultCorsPolicyService(logger)
                {
                    AllowedOrigins = { "*", "*" }
                };
            });
            services.AddSingleton<AdUserFactory>();

            return services;
        }

        public static IMapper GetMapper()
        {
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new UsuarioMapper());
            });

            IMapper mapper = mapperConfig.CreateMapper();

            return mapper;
        }

        private static IServiceCollection AddEntity(this IServiceCollection services)
        {
            services.AddDbContext<AuthDbContext>();
            services.AddTransient<IGlobalDbTransaction, GlobalDbTransaction<AuthDbContext>>();
            services.AddTransient(typeof(IEntityRepository<>), typeof(EntityRepository<>));

            return services;
        }

        private static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<PasswordHasherOptions>(options =>
            {
                options.CompatibilityMode = PasswordHasherCompatibilityMode.IdentityV2;
            });

            //services.AddAuthentication(NegotiateDefaults.AuthenticationScheme)
            //   .AddNegotiate();

            services.AddIdentity<ApplicationUser, IdentityRole>(config =>
            {
                config.Password.RequiredLength = 4;
                config.Password.RequireDigit = false;
                config.Password.RequireNonAlphanumeric = false;
                config.Password.RequireUppercase = false;
            })
            // .AddSignInManager<ApplicationSignInManager>() é possível adicinoar sign in customizado
            .AddEntityFrameworkStores<AuthDbContext>()
            .AddDefaultTokenProviders();

            services.ConfigureApplicationCookie(config =>
            {
                config.Cookie.Name = "IdentityServer.Cookie";
                config.LoginPath = "/Account/Login";
                config.LogoutPath = "/Account/Logout";
            });

            var clients = Config.Clients(configuration);
            var builder = services.AddIdentityServer(options =>
            {
                options.Events.RaiseErrorEvents = true;
                options.Events.RaiseInformationEvents = true;
                options.Events.RaiseFailureEvents = true;
                options.Events.RaiseSuccessEvents = true;
            })
            .AddDeveloperSigningCredential()
            .AddInMemoryIdentityResources(Config.Ids)
            .AddInMemoryApiResources(Config.Apis)
            .AddInMemoryApiScopes(Config.ApiScope)
            .AddInMemoryClients(clients)
            .AddProfileService<ProfileServiceApp>()
            .AddAspNetIdentity<ApplicationUser>();

            return services;
        }

        private static IServiceCollection AddUtils(this IServiceCollection services)
        {
            services.AddTransient<ViewModelFactory>();

            return services;
        }
    }

    public class CorsPolicyService : ICorsPolicyService
    {
        public Task<bool> IsOriginAllowedAsync(string origin)
        {
            return Task.FromResult(true);
        }
    }
}