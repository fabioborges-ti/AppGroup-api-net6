using AppGroup.Rental.Domain.Dtos.Orders;
using AppGroup.Rental.Domain.Interfaces.Repositories;
using AppGroup.Rental.Infrastructure.Database.Repositories.Base;
using Dapper;
using Microsoft.Extensions.Configuration;

namespace AppGroup.Rental.Infrastructure.Database.Repositories;

public class OrdersRepository : BaseRepository, IOrderRepository
{
    public OrdersRepository(IConfiguration configuration) : base(configuration) { }

    public async Task<Guid> CreateOrder(CreateOrderDto order)
    {
        await OpenConnectionAsync();

        var queryInsert = @"insert into public.tb_orders(""Id"", ""RaceValue"", ""Status"", ""CreatedAt"") values(@Id, @RaceValue, 0, @CreatedAt); ";

        await Connection.ExecuteAsync(queryInsert, order);

        await CloseConnectionAsync();

        return order.Id;
    }

    public async Task UpdateMotodriver(Guid orderId, Guid motodriver, int status)
    {
        await OpenConnectionAsync();

        var query = @$"update public.tb_orders set ""MotodriverId"" = '{motodriver}', ""Status"" = {status}, ""LastModifiedAt"" = CURRENT_DATE where ""Id"" = '{orderId}'; ";

        await Connection.ExecuteAsync(query);

        await CloseConnectionAsync();
    }
}
