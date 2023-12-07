using AutoMapper;
using Chamados.Application;
using Chamados.Application.AutoMapper;
using Chamados.Application.Interfaces;
using Chamados.Data.Context;
using Core.Application;
using Core.Data.Repositories;
using Core.Domain.Interfaces;
using Core.Domain.Interfaces.Repositories;
using Core.Infrastructure;
using Core.Utils.Extension;
using Microsoft.Extensions.DependencyInjection;

namespace Chamados.Configuration
{
    /// <summary>
    /// Classe para registro o app
    /// </summary>
    public static class AppRegistration
    {
        /// <summary>
        /// Adicionar services dos chamados
        /// </summary>
        /// <param name="services">Service collection</param>
        /// <returns>Service collection</returns>
        public static IServiceCollection AddChamados(this IServiceCollection services)
        {
            services.AddEntity()
                    .AddHttpClient()
                    .AddHttpContextAccessor();

            services.AddTransient<IFormularioServiceApp>(s => ServiceAppProxy<IFormularioServiceApp>.Wrap(s, new FormularioServiceApp(s)));
            services.AddTransient<IChamadoServiceApp>(s => ServiceAppProxy<IChamadoServiceApp>.Wrap(s, new ChamadoServiceApp(s)));
            services.AddTransient<IDashboardAppService>(s => ServiceAppProxy<IDashboardAppService>.Wrap(s, new DashboardAppService(s)));
            services.AddTransient<INotificarServiceApp>(s => ServiceAppProxy<INotificarServiceApp>.Wrap(s, new NotificarServiceApp(s)));
            services.AddTransient<HttpTokenClientFactory>();

            services.RegisterAllTypes(typeof(IUseCase<,>), new[] { typeof(AppRegistration).Assembly });
            services.AddScoped<IMapper>((s) =>
            {
                return GetMapper(s);
            });

            return services;
        }

        private static IServiceCollection AddEntity(this IServiceCollection services)
        {
            services.AddDbContext<ChamadosDbContext>();
            services.AddTransient<IGlobalDbTransaction, GlobalDbTransaction<ChamadosDbContext>>();
            services.AddTransient<IDbContextFactory, GlobalDbTransaction<ChamadosDbContext>>();
            services.AddTransient(typeof(IEntityRepository<>), typeof(EntityRepository<>));

            return services;
        }

        private static IMapper GetMapper(IServiceProvider serviceProvider)
        {
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new FormularioMapperProfile(serviceProvider));
                mc.AddProfile(new ChamadoMapperProfile());
            });

            IMapper mapper = mapperConfig.CreateMapper();

            return mapper;
        }
    }
}