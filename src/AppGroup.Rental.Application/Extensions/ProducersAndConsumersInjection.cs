using AppGroup.Rental.Application.Consumer;
using AppGroup.Rental.Infrastructure.RabbitMQ;
using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AppGroup.Rental.Application.Extensions;

public static class ProducersAndConsumersInjection
{
    public static void AddProducersAndConsumers(this IServiceCollection services, IConfiguration configuration)
    {
        var hostname = configuration["RabbitConfig:HostName"];
        var username = configuration["RabbitConfig:UserName"];
        var password = configuration["RabbitConfig:Password"];

        services.AddMessageService(x =>
        {
            services.AddMassTransit(x =>
            {
                x.AddConsumer<OrderConsumer>();

                x.AddBus(provider => Bus.Factory.CreateUsingRabbitMq(cfg =>
                {
                    cfg.Host(new Uri(hostname!), h =>
                    {
                        h.Username(username);
                        h.Password(password);
                    });

                    cfg.ReceiveEndpoint("create-order", ec =>
                    {
                        ec.ConfigureConsumer<OrderConsumer>(provider);
                    });
                }));
            });
        });
    }
}
