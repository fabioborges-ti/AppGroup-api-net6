using AppGroup.Rental.Domain.Dtos.Motodrivers;
using AppGroup.Rental.Domain.Dtos.Rent;
using AppGroup.Rental.Domain.Interfaces.Repositories;
using AppGroup.Rental.Infrastructure.Database.Repositories.Base;
using Dapper;
using Microsoft.Extensions.Configuration;

namespace AppGroup.Rental.Infrastructure.Database.Repositories;

public class RentRepository : BaseRepository, IRentRepository
{
    public RentRepository(IConfiguration configuration) : base(configuration) { }

    public async Task AcceptRent(Guid id, string plateNumber)
    {
        await OpenConnectionAsync();

        var queryUpdate = @$"update public.tb_rents set ""Status"" = 1, ""LastModifiedAt"" = CURRENT_DATE where ""Id"" = '{id}'; 
                             update public.tb_motorcycles set ""Status"" = 1, ""LastModifiedAt"" = CURRENT_DATE where ""PlateNumber"" = '{plateNumber}' ";

        await Connection.QueryAsync<int>(queryUpdate);

        await CloseConnectionAsync();
    }

    public async Task<bool> CheckIfExistRentByMotorcycleId(Guid id)
    {
        await OpenConnectionAsync();

        var queryCheck = @$"select 1 from public.tb_rents where ""MotorcycleId"" = '{id}' ";

        var result = await Connection.QueryAsync<int>(queryCheck);

        await CloseConnectionAsync();

        return result.Any();
    }

    public async Task<bool> CheckIfExistsPendingRent(Guid motodriverId, Guid motorcycleId)
    {
        await OpenConnectionAsync();

        var queryCheck = @$"select 1 
                              from public.tb_rents as a 
                             where 1 = 1 
                               and a.""Status"" in (0, 1)  
                               and (a.""MotodriverId"" = '{motodriverId}' or a.""MotorcycleId"" = '{motorcycleId}') ";

        var result = await Connection.QueryAsync<int>(queryCheck);

        await CloseConnectionAsync();

        return result.Any();
    }

    public async Task<Guid> Create(CreateProposalDto proposal)
    {
        await OpenConnectionAsync();

        var queryInsert = @"INSERT INTO public.tb_rents(""Id"", ""Start"", ""Forecast"", ""ValueForecast"", ""MotodriverId"", ""MotorcycleId"", ""PriceId"", ""Status"", ""CreatedAt"") VALUES(@Id, @Start, @Forecast, @ValueForecast, @MotodriverId, @MotorcycleId, @PriceId, 0, CURRENT_DATE) ";

        await Connection.ExecuteAsync(queryInsert, proposal);

        await CloseConnectionAsync();

        return proposal.Id;
    }

    public async Task<GetRentDto> GetRent(Guid id)
    {
        await OpenConnectionAsync();

        var query = $@"select c.""Id"", a.""Name"", a.""Cnpj"", a.""Birthday"", a.""Cnh"", a.""CnhType"", b.""Model"", b.""PlateNumber"", b.""Year"", d.""Start"",d.""Forecast"", d.""ValueForecast"", d.""Status"", c.""Days"", c.""Daily"", d.""TotalPrice"", d.""MotodriverId"" 
                         from public.tb_motodrivers as a, public.tb_motorcycles as b, public.tb_prices as c, public.tb_rents as d 
                        where 1 = 1 
                          and d.""MotodriverId"" = a.""Id"" 
                          and d.""MotorcycleId"" = b.""Id"" 
                          and d.""PriceId"" = c.""Id"" 
                          and d.""Id"" = '{id}' ";

        var result = await Connection.QueryFirstOrDefaultAsync<GetRentDto>(query);

        await CloseConnectionAsync();

        return result!;
    }

    public async Task CloseRent(Guid id, double totalPrice, string plateNumber)
    {
        await OpenConnectionAsync();

        var queryUpdate = @$"update public.tb_rents set ""End"" = CURRENT_DATE, ""Status"" = 2, ""TotalPrice"" = {totalPrice}, ""LastModifiedAt"" = CURRENT_DATE where ""Id"" = '{id}';
                             update public.tb_motorcycles set ""Status"" = 0, ""LastModifiedAt"" = CURRENT_DATE where ""PlateNumber"" = '{plateNumber}' ";

        await Connection.ExecuteAsync(queryUpdate);

        await CloseConnectionAsync();
    }

    public async Task<List<GetMotodriverDto>> GetMotodriversAvaiables()
    {
        await OpenConnectionAsync();

        var query = @"select a.""Id"", a.""CnhType"" 
                        from public.tb_motodrivers as a, public.tb_rents as b 
                       where 1 = 1 
                         and a.""CnhType"" = 1 
                         and b.""Status"" = 1 ";

        var result = await Connection.QueryAsync<GetMotodriverDto>(query);

        await CloseConnectionAsync();

        return result.ToList();
    }

    public async Task<GetRentDto> GetRentByCnh(string cnh, int status)
    {
        await OpenConnectionAsync();

        var query = $@"select d.""Id"", a.""Name"", a.""Cnpj"", a.""Birthday"", a.""Cnh"", a.""CnhType"", b.""Model"", b.""PlateNumber"", b.""Year"", d.""Start"",d.""Forecast"", d.""ValueForecast"", d.""Status"", c.""Days"", c.""Daily"", d.""TotalPrice"", d.""MotodriverId"" 
                         from public.tb_motodrivers as a, public.tb_motorcycles as b, public.tb_prices as c, public.tb_rents as d 
                        where 1 = 1 
                          and d.""MotodriverId"" = a.""Id"" 
                          and d.""MotorcycleId"" = b.""Id"" 
                          and d.""PriceId"" = c.""Id"" 
                          and d.""Status"" = {status} 
                          and a.""Cnh"" = '{cnh}' ";

        var result = await Connection.QueryFirstOrDefaultAsync<GetRentDto>(query);

        await CloseConnectionAsync();

        return result!;
    }

    public async Task<List<GetRentDto>> GetRents()
    {
        await OpenConnectionAsync();

        var query = $@"select a.""Id"", b.""Name"", b.""Cnpj"", b.""Birthday"", b.""Cnh"", b.""CnhType"", c.""Model"", c.""PlateNumber"", c.""Year"",  a.""Start"",  a.""Forecast"", a.""ValueForecast"", a.""Status"", d.""Days"",  d.""Daily"", a.""TotalPrice"" 
                        from public.tb_rents as a, public.tb_motodrivers as b, public.tb_motorcycles as c, public.tb_prices as d 
                       where 1 = 1 
                         and a.""MotodriverId"" = b.""Id"" 
                         and a.""MotorcycleId"" = c.""Id"" 
                         and a.""PriceId"" = d.""Id"" 
                    order by a.""CreatedAt"" desc ";

        var result = await Connection.QueryAsync<GetRentDto>(query);

        await CloseConnectionAsync();

        return result.ToList();
    }
}
