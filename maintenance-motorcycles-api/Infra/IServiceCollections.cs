using Application.Interface;
using Application.Service;
using Data.Dapper;
using Data.Entity;
using Domain.Configuration;
using Domain.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Infra
{
    public static class IServiceCollections
    {
        public static IServiceCollection AddConfiguration(this IServiceCollection services)
        {
            services.AddDapper()
                .AddDbContext()
                .AddServices();

            return services;
        }

        public static IServiceCollection AddDapper(this IServiceCollection services)
        {
            services.AddSingleton<DapperContext>();

            services.AddScoped<MaintenanceRepository, MaintenanceRepositoryImp>();

            return services;
        }

        public static IServiceCollection AddDbContext(this IServiceCollection services)
        {
            services.AddDbContext<DataContext>((serviceProvider, options) =>
            {
                var databaseOptions = serviceProvider.GetService<IOptions<ConnectionStringsOptions>>()!.Value;

                options.UseSqlServer(databaseOptions.DefaultConnection);
            });

            services.AddScoped(typeof(DatabaseContext<>), typeof(DatabaseContextImp<>));

            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<MaintenanceService, MaintenanceServiceImp>();

            return services;
        }
    }
}
