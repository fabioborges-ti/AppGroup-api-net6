using System.Text.Json.Serialization;

namespace AppGroup.Rental.Domain.Dtos.Notifications;

public class CreateNotificationsDto
{
    public Guid OrderId { get; set; }
    public Guid MotodriverId { get; set; }

    [JsonIgnore]
    public Guid Id { get; set; } = Guid.NewGuid();
}
