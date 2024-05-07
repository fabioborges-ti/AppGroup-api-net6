using AppGroup.Rental.Domain.Dtos.Deliveries;
using AppGroup.Rental.Domain.Interfaces.Repositories;
using AppGroup.Rental.Infrastructure.Database.Repositories.Base;
using Dapper;
using Microsoft.Extensions.Configuration;

namespace AppGroup.Rental.Infrastructure.Database.Repositories;

public class DeliveryRepository : BaseRepository, IDeliveryRepository
{
    public DeliveryRepository(IConfiguration configuration) : base(configuration) { }

    public async Task AcceptDelivery(AcceptDeliveryDto delivery)
    {
        await OpenConnectionAsync();

        var transaction = Connection.BeginTransaction();

        try
        {
            var queryOrder = $@"update public.tb_orders set ""Status"" = {delivery.Status}, ""MotodriverId"" = '{delivery.MotodriverId}', ""LastModifiedAt"" = CURRENT_DATE where ""Id"" = '{delivery.OrderId}'; ";

            await Connection.ExecuteAsync(queryOrder);

            var queryNotifications = $@"update public.tb_notifications set ""LastModifiedAt"" = CURRENT_DATE where ""OrderId"" = '{delivery.OrderId}'; ";

            await Connection.ExecuteAsync(queryNotifications);

            transaction.Commit();
        }
        catch
        {
            transaction.Rollback();
        }

        await CloseConnectionAsync();
    }

    public async Task<bool> CheckIfExistDelivery(Guid orderId, Guid motodriverId)
    {
        await OpenConnectionAsync();

        var query = $@"select 1 
                         from public.tb_orders as a 
                        where 1 = 1 
                          and a.""Id"" = '{orderId}' 
                          and a.""MotodriverId"" = '{motodriverId}' 
                          and a.""Status"" = 1 ";

        var result = await Connection.QueryFirstOrDefaultAsync<int>(query);

        await CloseConnectionAsync();

        return result > 0;
    }

    public async Task<bool> CheckIfExistPendingDelivery(Guid motodriverId)
    {
        await OpenConnectionAsync();

        var query = $@"select 1 from public.tb_orders as a where a.""Status"" = 1 and a.""MotodriverId"" = '{motodriverId}' ";

        var result = await Connection.QueryFirstOrDefaultAsync<int>(query);

        await CloseConnectionAsync();

        return result > 0;
    }

    public async Task CloseDelivery(CloseDeliveryDto order)
    {
        await OpenConnectionAsync();

        var query = $@"update public.tb_orders set ""Status"" = {order.Status}, ""MotodriverId"" = '{order.MotodriverId}', ""LastModifiedAt"" = CURRENT_DATE where ""Id"" = '{order.OrderId}'; ";

        await Connection.ExecuteAsync(query);

        await CloseConnectionAsync();
    }

    public async Task<PendingDeliveryDto> GetPendingDelivery()
    {
        await OpenConnectionAsync();

        var query = @"select b.""Id"", b.""CreatedAt"", b.""RaceValue""   
                        from public.tb_orders as b 
                       where 1 = 1 
                         and b.""Status"" = 0 
                    order by b.""CreatedAt"" desc 
                       limit 1 ";

        var result = await Connection.QueryFirstOrDefaultAsync<PendingDeliveryDto>(query);

        await CloseConnectionAsync();

        return result!;
    }

    public async Task<PendingDeliveryDto> GetPendingDelivery(string cnh)
    {
        await OpenConnectionAsync();

        var query = @$"select a.""Id"", a.""CreatedAt"", a.""RaceValue"" 
                        from public.tb_orders as a, public.tb_motodrivers as b  
                       where 1 = 1 
                         and a.""MotodriverId"" = b.""Id""
                         and a.""Status"" = 1
                         and b.""Cnh"" = '{cnh}' ";

        var result = await Connection.QueryFirstOrDefaultAsync<PendingDeliveryDto>(query);

        await CloseConnectionAsync();

        return result!;
    }
}
