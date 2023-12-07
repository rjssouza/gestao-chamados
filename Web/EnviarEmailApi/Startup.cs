using Core.Utils.Extension;
using Core.Utils.Json;
using EnviarEmail.Configuration;
using EnviarEmailApi.Attribute;
using EnviarEmailApi.Filter;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Logging;
using Microsoft.OpenApi.Models;
using System.Text.Json;

namespace EnviarEmailApi
{
    /// <summary>
    ///
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
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

            app.UseSwagger(c =>
            {
                c.SerializeAsV2 = true;
            });

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "EnviarEmailApi");
                c.RoutePrefix = string.Empty;
            });

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        /// <summary>
        /// This method gets called by the runtime. Use this method to add services to the container.
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            //https://qawithexperts.com/article/asp-net/enabling-cors-in-iis-various-possible-methods/291
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
            SecureApi(services, configuration);

            services.AddEnviarEmail();

            services.AddControllers();

            services.AddMvc(options =>
            {
                options.Filters.Add(typeof(ExceptionFilter));
            }).AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
                options.JsonSerializerOptions.Converters.Add(new JsonConverterByteArrayGlobal());
            });

            services.AddSwaggerGen(c =>
            {
                c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First()); //This line

                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Enviar Email",
                    Description = "Disparo de email internos via smtp - API",
                    TermsOfService = new Uri("https://example.com/terms"),
                    Contact = new OpenApiContact
                    {
                        Name = "Nemak",
                        Email = string.Empty,
                        Url = new Uri("https://twitter.com/nemak"),
                    },
                    License = new OpenApiLicense
                    {
                        Name = "Use under LICX",
                        Url = new Uri("https://example.com/license"),
                    }
                });

                // c.EnableAnnotations();
                c.OperationFilter<CustomHeaderSwaggerAttribute>();

                var security = new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                            Scheme = "oauth2",
                            Name = "Bearer",
                            In = ParameterLocation.Header,
                        },
                        Array.Empty<string>()
                    }
                };

                c.AddSecurityDefinition(
                    "Bearer",
                    new OpenApiSecurityScheme
                    {
                        Description = "Copie 'Bearer ' + token'",
                        Name = "Authorization",
                        In = ParameterLocation.Header,
                        Type = SecuritySchemeType.ApiKey,
                        Scheme = "Bearer"
                    });

                c.AddSecurityRequirement(security);

                foreach (var name in Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory, "*.SwaggerDoc.XML", SearchOption.AllDirectories))
                {
                    c.IncludeXmlComments(name);
                }
            });
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        private static void SecureApi(IServiceCollection services, IConfiguration configuration)
        {
            var authority = configuration.GetSection("Authority").Value;

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer("Bearer", o =>
            {
                o.Authority = authority;
                o.Audience = "EnviarEmailApi";
                o.RequireHttpsMetadata = true;
            });
        }
    }
}