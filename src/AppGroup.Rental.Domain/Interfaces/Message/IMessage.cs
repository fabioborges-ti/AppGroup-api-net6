namespace AppGroup.Rental.Domain.Interfaces.Message;

public interface IMessage
{
    Task SendToEndPointAsync<T>(T value, string fila) where T : class;
}
