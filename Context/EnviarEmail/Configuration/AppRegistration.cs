using Core.Application;
using Core.Domain.Interfaces;
using Core.Utils.Extension;
using EnviarEmail.Application;
using EnviarEmail.Application.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace EnviarEmail.Configuration
{
    /// <summary>
    /// Classe para registro o app
    /// </summary>
    public static class AppRegistration
    {
        /// <summary>
        /// Adicionar services dos EnviarEmail
        /// </summary>
        /// <param name="services">Service collection</param>
        /// <returns>Service collection</returns>
        public static IServiceCollection AddEnviarEmail(this IServiceCollection services)
        {
            services.AddEntity()
                    .AddHttpClient()
                    .AddHttpContextAccessor();

            services.AddTransient<IEnviarAppService>(s => ServiceAppProxy<IEnviarAppService>.Wrap(s, new EnviarAppService(s)));
            services.RegisterAllTypes(typeof(IUseCase<,>), new[] { typeof(AppRegistration).Assembly });

            return services;
        }

        private static IServiceCollection AddEntity(this IServiceCollection services)
        {
            return services;
        }
    }
}