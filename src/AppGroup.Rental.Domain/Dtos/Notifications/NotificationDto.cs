#nullable disable

using AppGroup.Rental.Domain.Enums;

namespace AppGroup.Rental.Domain.Dtos.Notifications;

public class NotificationDto
{
    public Guid Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public double RaceValue { get; set; }
    public StatusOrder Status { get; set; }
    public List<MotodriverNotificationDto> Motodrivers { get; set; }
}

public class MotodriverNotificationDto
{
    public Guid MotodriverId { get; set; }
    public string Name { get; set; }
    public string Cnpj { get; set; }
    public string Cnh { get; set; }
}
