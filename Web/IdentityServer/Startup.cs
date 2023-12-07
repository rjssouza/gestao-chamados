using Chamados.Configuration;
using Core.Utils.Extension;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Logging;

namespace IdentityServer
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors(); // allow credentials

            //em ambientes de produção não deve existir.
            //usado para pegar pilhas de erros
            IdentityModelEventSource.ShowPII = true;

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseIdentityServer();
            app.UseStaticFiles();
            app.UseMvcWithDefaultRoute();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(
                    builder =>
                    {
                        builder.WithOrigins("*");
                        builder.AllowAnyHeader();
                        builder.AllowAnyMethod();
                    }
                );
            });
#if DEBUG
            var configuration = services.LoadConfig(true);
#else
            var configuration = services.LoadConfig();
#endif
            services.AddAuth(configuration);
            services.AddMvc(options => options.EnableEndpointRouting = false);
        }
    }
}