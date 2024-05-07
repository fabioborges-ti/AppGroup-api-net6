using AppGroup.Rental.Domain.Interfaces.Repositories;
using AppGroup.Rental.Infrastructure.Database.Context;
using AppGroup.Rental.Infrastructure.Database.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AppGroup.Rental.Infrastructure.Database.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

        #region Repositories

        services.AddScoped<IMotorcyclesRepository, MotorcyclesRepository>();
        services.AddScoped<IMotodriversRepository, MotodriversRepository>();
        services.AddScoped<IRentRepository, RentRepository>();
        services.AddScoped<IOrderRepository, OrdersRepository>();
        services.AddScoped<INotificationRepository, NotificationRepository>();
        services.AddScoped<IDeliveryRepository, DeliveryRepository>();

        #endregion

        return services;
    }
}
