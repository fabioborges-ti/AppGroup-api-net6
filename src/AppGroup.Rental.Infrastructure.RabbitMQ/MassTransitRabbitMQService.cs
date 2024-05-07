using AppGroup.Rental.Domain.Interfaces.Message;
using MassTransit;
using Microsoft.Extensions.Configuration;

namespace AppGroup.Rental.Infrastructure.RabbitMQ;

public class MassTransitRabbitMQService : IMessage
{
    private readonly IBus _bus;
    private readonly string _connectionsStringRabbitMq;

    public MassTransitRabbitMQService(IBus bus, IConfiguration configuration)
    {
        _bus = bus;
        _connectionsStringRabbitMq = configuration["RabbitConfig:HostName"];

        if (string.IsNullOrWhiteSpace(_connectionsStringRabbitMq))
            throw new InvalidOperationException("RabbitConfig:HostName");
    }

    public async Task SendToEndPointAsync<T>(T value, string fila) where T : class
    {
        var uri = new Uri($"{_connectionsStringRabbitMq!}/{fila}");
        var endPoint = await _bus.GetSendEndpoint(uri);

        await endPoint.Send(value);
    }
}
