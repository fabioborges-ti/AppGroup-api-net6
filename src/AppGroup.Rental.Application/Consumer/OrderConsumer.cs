using AppGroup.Rental.Domain.Dtos.Rabbit;
using MassTransit;
using Microsoft.Extensions.Logging;

namespace AppGroup.Rental.Application.Consumer;

public class OrderConsumer : IConsumer<MessageDto>
{
    private readonly ILogger<OrderConsumer> _logger;

    public OrderConsumer(ILogger<OrderConsumer> logger)
    {
        _logger = logger;
    }

    public async Task Consume(ConsumeContext<MessageDto> context)
    {
        var message = context.Message;

        _logger.LogInformation("Order '{orderId}' received successfully", message.OrderId);

        await Task.CompletedTask;
    }
}
