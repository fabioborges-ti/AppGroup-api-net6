using AppGroup.Rental.Domain.Interfaces.Message;
using MassTransit;
using MassTransit.ExtensionsDependencyInjectionIntegration;
using Microsoft.Extensions.DependencyInjection;

namespace AppGroup.Rental.Infrastructure.RabbitMQ;

public static class MessageQueueInjection
{
    public static void AddMessageService(this IServiceCollection services, Action<IServiceCollectionBusConfigurator> serviceCollectionBusConfigurator)
    {
        services.AddMassTransit(serviceCollectionBusConfigurator);

        services.AddMassTransitHostedService(true);

        services.AddTransient<IMessage, MassTransitRabbitMQService>();
    }
}
