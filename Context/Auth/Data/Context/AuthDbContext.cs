using Core.Constants;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Security.Domain.Entities;

namespace Auth.Data.Context
{
    public class AuthDbContext : IdentityDbContext<ApplicationUser>
    {
        private const string DB_NAME = "BDCHNORIS";

        private static bool updateDatabase = true;

        private readonly IConfiguration _configuration;

        public AuthDbContext(DbContextOptions<AuthDbContext> options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;

            if (updateDatabase)
            {
                Database.Migrate();
                updateDatabase = false;
            }
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var connectionString = _configuration[ConfigKeyConstants.STRING_CONNECTION] ?? throw new ArgumentNullException(optionsBuilder.GetType().Name);
                optionsBuilder
                    .UseLazyLoadingProxies()
                    .UseSqlServer(string.Format(connectionString, DB_NAME), x => x.MigrationsHistoryTable("__EFMigrationsHistory"));
            }

            optionsBuilder.EnableSensitiveDataLogging();

            base.OnConfiguring(optionsBuilder);
        }
    }
}