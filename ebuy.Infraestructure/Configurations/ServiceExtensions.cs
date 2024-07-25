using ebuy.Application.Common.Interfaces.Repositories;
using ebuy.Domain.Interfaces;
using ebuy.Infraestructure.Context;
using ebuy.Infraestructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ebuy.Infraestructure.Configurations
{
    public static class ServiceExtensions
    {
        public static void ConfigureInfraestructureApp(this IServiceCollection services,
                                                   IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("SqlServer") ?? throw new ArgumentNullException("ConnectionStrings.SqlServer not found in appsettings");

            services.AddDbContext<EbuyDbContext>(opt => opt.UseSqlServer(connectionString,
                                                                            sqlServerOptionsAction: SqlServerDbContextOptionsExtensions =>
                                                                            {
                                                                                SqlServerDbContextOptionsExtensions.MigrationsAssembly("ebuy.Infraestructure");
                                                                                SqlServerDbContextOptionsExtensions.EnableRetryOnFailure(maxRetryCount: 15, maxRetryDelay: TimeSpan.FromSeconds(30), null);
                                                                            }));

            //services.AddScoped<IUnitOfWork, UnitOfWork>();
            //services.AddScoped<IUserRepository, UserRepository>();
        }
    }
}
