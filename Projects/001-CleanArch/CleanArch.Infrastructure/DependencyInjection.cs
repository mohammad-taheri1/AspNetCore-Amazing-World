using CleanArch.Infrastructure.Persistence.MSSQLServer;
using CleanArch.Infrastructure.Persistence.PostgreSQL;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArch.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureDI(this IServiceCollection services , IConfiguration configuration)
        {
            #region Config MSSQLServer Database
            services.AddDbContext<AppMSSQLDbContext>(options =>
            {
                var connectionString = configuration.GetConnectionString("localmssql");
                options.UseSqlServer(connectionString);
            });
            #endregion

            #region Config PostgreSQL Database
            services.AddDbContext<AppPostgreSQLDbContext>(options =>
            {
                var connectionString = configuration.GetConnectionString("localpostgresql");
                options.UseNpgsql(connectionString);
            });
            #endregion

            return services;
        }
    }
}
