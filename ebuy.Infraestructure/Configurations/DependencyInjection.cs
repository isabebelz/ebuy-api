using ebuy.Application.Common.Configurations.DependencyInjection;
using ebuy.Application.Common.Interfaces.Repositories;
using ebuy.Application.Services.EmailService;
using ebuy.Domain.Interfaces;
using ebuy.Domain.Interfaces.Services;
using ebuy.Domain.Notifications;
using ebuy.Infraestructure.Repositories;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Serialization;

namespace ebuy.Infraestructure.Configurations
{
    public static class DependencyInjection
    {
        public static IServiceCollection ConfigureDepencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddNotifications()
                    .AddApplications(configuration)
                    .AddServices()
                    .AddRepositories()
                    .AddQueries();

            return services;
        }

        public static IServiceCollection AddNotifications(this IServiceCollection services)
        {
            services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();
            services.AddScoped<INotificationHandler<DomainSuccesNotification>, DomainSuccesNotificationHandler>();

            return services;
        }

        private static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped(typeof(IEncryptService), typeof(EncryptService));
            services.AddScoped(typeof(IEmailService), typeof(EmailService));

            return services;
        }

        private static IServiceCollection AddApplications(this IServiceCollection services, IConfiguration configuration)
        {
            ApplicationServices.AddApplicationServices(services);

            services.AddMemoryCache();

            services.AddControllers()
                    .AddNewtonsoftJson(options =>
                    {
                        options.SerializerSettings.ContractResolver = new DefaultContractResolver
                        {
                            NamingStrategy = null
                        };
                        options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                    })
                    .AddJsonOptions(options =>
                    {
                        options.JsonSerializerOptions.PropertyNamingPolicy = null;
                    });

            return services;
        }

        private static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddScoped(typeof(IUserRepository), typeof(UserRepository));
            services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));

            return services;
        }

        private static IServiceCollection AddQueries(this IServiceCollection services)
        {

            return services;
        }
    }
}
