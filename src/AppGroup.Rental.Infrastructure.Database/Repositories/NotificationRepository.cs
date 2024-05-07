#nullable disable

using AppGroup.Rental.Domain.Dtos.Notifications;
using AppGroup.Rental.Domain.Interfaces.Repositories;
using AppGroup.Rental.Infrastructure.Database.Repositories.Base;
using Dapper;
using Microsoft.Extensions.Configuration;
using System.Text;

namespace AppGroup.Rental.Infrastructure.Database.Repositories;

public class NotificationRepository : BaseRepository, INotificationRepository
{
    public NotificationRepository(IConfiguration configuration) : base(configuration) { }

    public async Task Create(List<CreateNotificationsDto> notifications)
    {
        var query = new StringBuilder();

        notifications.ForEach(x =>
        {
            var id = Guid.NewGuid();
            var orderId = x.OrderId;
            var motodriverId = x.MotodriverId;

            query.Append($@"insert into tb_notifications(""Id"", ""OrderId"", ""MotodriverId"", ""CreatedAt"") values('{id}', '{orderId}', '{motodriverId}', CURRENT_DATE); ");
        });

        await OpenConnectionAsync();

        await Connection.ExecuteAsync(query.ToString());

        await CloseConnectionAsync();

        query.Clear();
    }

    public async Task Create(CreateNotificationsDto notification)
    {
        await OpenConnectionAsync();

        var query = @$"insert into public.tb_notifications(""Id"", ""OrderId"", ""MotodriverId"", ""CreatedAt"", ""CreatedBy"") values('{notification.Id}', '{notification.OrderId}', '{notification.MotodriverId}', CURRENT_DATE, '{notification.MotodriverId}'); ";

        await Connection.ExecuteAsync(query);

        await CloseConnectionAsync();
    }

    public async Task<bool> ExistsNotificationOrder(Guid orderId, Guid motodriverId)
    {
        await OpenConnectionAsync();

        var queryCheck = @$"select 1 from public.tb_notifications as a where a.""OrderId"" = '{orderId}' and a.""MotodriverId"" = '{motodriverId}' ";

        var result = await Connection.QueryAsync<int>(queryCheck);

        await CloseConnectionAsync();

        return result.Any();
    }

    public async Task<IEnumerable<NotificationDto>> ListNotifications()
    {
        var notifications = new List<NotificationDto>();

        await OpenConnectionAsync();

        var query = @"select a.""Id"", a.""CreatedAt"", a.""RaceValue"", a.""Status"", a.""MotodriverId"", c.""Name"", c.""Cnpj"", c.""Cnh""
                        from public.tb_orders as a, public.tb_notifications as b, public.tb_motodrivers as c 
                       where 1 = 1 
                         and a.""Id"" = b.""OrderId"" 
                         and a.""MotodriverId"" = c.""Id"" 
                    order by a.""CreatedAt"" desc ";

        await Connection.QueryAsync<NotificationDto, MotodriverNotificationDto, NotificationDto>(query,
            (notification, motodriver) =>
            {
                if (notifications.SingleOrDefault(a => a.Id == notification.Id) == null)
                {
                    notification.Motodrivers = new List<MotodriverNotificationDto>();

                    notifications.Add(notification);
                }
                else
                {
                    notification = notifications.SingleOrDefault(a => a.Id == notification.Id);
                }

                if (notification.Motodrivers.SingleOrDefault(a => a.MotodriverId == motodriver.MotodriverId) == null)
                {
                    notification.Motodrivers.Add(motodriver);
                }

                return notification;

            }, splitOn: "MotodriverId");

        await CloseConnectionAsync();

        return notifications;
    }

    public async Task Update(Guid orderId, Guid motodriverId)
    {
        await OpenConnectionAsync();

        var query = @$"update public.tb_notifications set ""LastModifiedAt"" = CURRENT_DATE where ""OrderId"" = '{orderId}' and ""MotodriverId"" = '{motodriverId}' ";

        await Connection.ExecuteAsync(query);

        await CloseConnectionAsync();
    }
}
