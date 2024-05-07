using AppGroup.Rental.Domain.Dtos.Motodrivers;
using AppGroup.Rental.Domain.Interfaces.Repositories;
using AppGroup.Rental.Infrastructure.Database.Repositories.Base;
using Dapper;
using Microsoft.Extensions.Configuration;

namespace AppGroup.Rental.Infrastructure.Database.Repositories;

public class MotodriversRepository : BaseRepository, IMotodriversRepository
{
    public MotodriversRepository(IConfiguration configuration) : base(configuration) { }

    public async Task<Guid> Create(CreateMotodriverDto motodriver)
    {
        await OpenConnectionAsync();

        var queryInsert = @"INSERT INTO public.tb_motodrivers(""Id"", ""Name"", ""Cnpj"", ""Birthday"", ""Cnh"", ""CnhType"", ""CreatedAt"") VALUES(@Id, @Name, @Cnpj, @Birthday, @Cnh, @CnhType, @CreatedAt); ";

        await Connection.ExecuteAsync(queryInsert, motodriver);

        await CloseConnectionAsync();

        return motodriver.Id;
    }

    public async Task<bool> CheckIfExists(string cnpj, string cnh)
    {
        await OpenConnectionAsync();

        var queryCheck = @$"select 1 from public.tb_motodrivers where ""Cnpj"" = '{cnpj}' or ""Cnh"" = '{cnh}' ";

        var result = await Connection.QueryAsync<int>(queryCheck);

        await CloseConnectionAsync();

        return result.Any();
    }

    public async Task<GetMotodriverDto?> GetByCnh(string cnh)
    {
        await OpenConnectionAsync();

        var queryCheck = @$"select * from public.tb_motodrivers where ""Cnh"" = '{cnh}' ";

        var result = await Connection.QueryFirstOrDefaultAsync<GetMotodriverDto>(queryCheck);

        await CloseConnectionAsync();

        return result;
    }

    public async Task UpdateImage(Guid id, string path)
    {
        await OpenConnectionAsync();

        var queryUpdate = @$"update public.tb_motodrivers set ""CnhImage"" = '{path}', ""LastModifiedAt"" = CURRENT_DATE where ""Id"" = '{id}' ";

        await Connection.ExecuteAsync(queryUpdate);

        await CloseConnectionAsync();
    }

    public async Task<GetMotodriverDto?> GetById(Guid id)
    {
        await OpenConnectionAsync();

        var queryCheck = @$"select * from public.tb_motodrivers where ""Id"" = '{id}' ";

        var result = await Connection.QueryFirstOrDefaultAsync<GetMotodriverDto>(queryCheck);

        await CloseConnectionAsync();

        return result;
    }

    public async Task<GetMotoDriversPagedDto> GetPaged(int page, int pagesize)
    {
        await OpenConnectionAsync();

        var result = new GetMotoDriversPagedDto();

        var query = $@"select ""Id"", ""Name"", ""Cnh"", ""CnhType"", ""Cnpj"", ""Birthday"" from public.tb_motodrivers limit @Pagesize offset @Offset; 
                       select count(*) from public.tb_motodrivers";

        using var multi = await Connection.QueryMultipleAsync(query,
            new
            {
                Offset = (page - 1) * page,
                Pagesize = pagesize
            });

        var data = multi.Read<MotodriverDto>().ToList();

        result.Items = data;
        result.Total = multi.ReadFirst<int>();
        result.Page = page;
        result.PageSize = pagesize;
        result.TotalPages = Math.Ceiling((double)result.Total / pagesize);

        await CloseConnectionAsync();

        return result;
    }

    public async Task<bool> CheckOrderPending(string cnh)
    {
        await OpenConnectionAsync();

        var queryCheck = @$"select 1 
                              from public.tb_motodrivers as a, public.tb_orders as b 
                             where 1 = 1 
                               and a.""Id"" = b.""MotodriverId""
                               and b.""Status"" = 1 
                               and a.""Cnh"" = '{cnh}' ";

        var result = await Connection.QueryFirstOrDefaultAsync<int>(queryCheck);

        await CloseConnectionAsync();

        return result > 0;
    }
}
