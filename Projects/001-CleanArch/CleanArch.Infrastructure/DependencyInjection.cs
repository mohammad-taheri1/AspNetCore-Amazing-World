using CleanArch.Infrastructure.Persistence.MSSQLServer;
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

            return services;
        }
    }
}
