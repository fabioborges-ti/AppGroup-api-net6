using AppGroup.Rental.Domain.Dtos.Motorcycles;
using AppGroup.Rental.Domain.Dtos.Prices;
using AppGroup.Rental.Domain.Interfaces.Repositories;
using AppGroup.Rental.Infrastructure.Database.Repositories.Base;
using Dapper;
using Microsoft.Extensions.Configuration;

namespace AppGroup.Rental.Infrastructure.Database.Repositories;

public class MotorcyclesRepository : BaseRepository, IMotorcyclesRepository
{
    public MotorcyclesRepository(IConfiguration configuration) : base(configuration) { }

    public async Task<bool> CheckIfExists(string plateNumber)
    {
        await OpenConnectionAsync();

        var queryCheck = @$"select 1 from public.tb_motorcycles as moto where moto.""PlateNumber"" = '{plateNumber}' ";

        var result = await Connection.QueryAsync<int>(queryCheck);

        await CloseConnectionAsync();

        return result.Any();
    }

    public async Task<Guid> Create(CreateMotorcyclesDto motocyle)
    {
        await OpenConnectionAsync();

        var queryInsert = @"INSERT INTO public.tb_motorcycles(""Id"", ""Model"", ""PlateNumber"", ""Year"", ""Status"", ""CreatedAt"") VALUES(@Id, @Model, @PlateNumber, @Year, 0, @CreatedAt); ";

        await Connection.ExecuteAsync(queryInsert, motocyle);

        await CloseConnectionAsync();

        return motocyle.Id;
    }

    public async Task<GetMotorcyclesPagedDto> GetPaged(int page, int pagesize, int status)
    {
        await OpenConnectionAsync();

        var result = new GetMotorcyclesPagedDto();

        var query = $@"select a.""Id"", a.""Model"", a.""PlateNumber"", a.""Year"", a.""Status"", a.""CreatedAt"" 
                        from public.tb_motorcycles as a 
                       where 1 = 1 
                         and a.""Status"" = {status} 
                       limit @Pagesize 
                      offset @Offset; 
                      select count(*) from public.tb_motorcycles as b where b.""Status"" = {status}; ";

        using var multi = await Connection.QueryMultipleAsync(query,
            new
            {
                Offset = (page - 1) * page,
                Pagesize = pagesize
            });

        var data = multi.Read<MotorcyclesDto>().ToList();

        result.Items = data;
        result.Total = multi.ReadFirst<int>();
        result.Page = page;
        result.PageSize = pagesize;
        result.TotalPages = Math.Ceiling((double)result.Total / pagesize);

        await CloseConnectionAsync();

        return result;
    }

    public async Task<MotorcyclesDto> GetByPlateNumber(string plateNumber)
    {
        await OpenConnectionAsync();

        var queryGet = $@"select * from public.tb_motorcycles where ""PlateNumber"" = '{plateNumber}';";

        var result = await Connection.QueryFirstOrDefaultAsync<MotorcyclesDto>(queryGet);

        await CloseConnectionAsync();

        return result!;
    }

    public async Task Delete(string plateNumber)
    {
        await OpenConnectionAsync();

        var queryDelete = $@"delete from public.tb_motorcycles where ""PlateNumber"" = '{plateNumber}' ";

        await Connection.ExecuteAsync(queryDelete);

        await CloseConnectionAsync();
    }

    public async Task Update(Guid id, string plateNumber)
    {
        await OpenConnectionAsync();

        var queryUpdate = $@"update public.tb_motorcycles set ""PlateNumber"" = '{plateNumber}', ""LastModifiedAt"" = CURRENT_DATE where ""Id"" = '{id}' ";

        await Connection.ExecuteAsync(queryUpdate);

        await CloseConnectionAsync();
    }

    public async Task<MotorcyclesDto?> GetById(Guid id)
    {
        await OpenConnectionAsync();

        var queryExists = $@"select * from public.tb_motorcycles where ""Id"" = '{id}' ";

        var result = await Connection.QueryFirstOrDefaultAsync<MotorcyclesDto>(queryExists);

        await CloseConnectionAsync();

        return result;
    }

    public async Task<List<GetPricesDto>> GetPrices()
    {
        await OpenConnectionAsync();

        var queryGet = @"select * from public.tb_prices order by ""Days"" ";

        var result = await Connection.QueryAsync<GetPricesDto>(queryGet);

        await CloseConnectionAsync();

        return result.ToList();
    }

    public async Task<GetPricesDto> GetPriceById(Guid id)
    {
        await OpenConnectionAsync();

        var queryGet = $@"select * from public.tb_prices where ""Id"" = '{id}' ";

        var result = await Connection.QueryFirstOrDefaultAsync<GetPricesDto>(queryGet);

        await CloseConnectionAsync();

        return result!;
    }
}
