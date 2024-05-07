using Microsoft.Extensions.Configuration;
using Npgsql;
using System.Data;

namespace AppGroup.Rental.Infrastructure.Database.Repositories.Base;

public abstract class BaseRepository
{
    public readonly NpgsqlConnection Connection;

    protected BaseRepository(IConfiguration configuration)
    {
        Connection = new NpgsqlConnection(configuration.GetConnectionString("DefaultConnection"));
    }

    public async Task OpenConnectionAsync()
    {
        if (Connection.State == ConnectionState.Closed)
            await Connection.OpenAsync();
    }

    public async Task CloseConnectionAsync()
    {
        if (Connection.State != ConnectionState.Closed)
            await Connection.CloseAsync();
    }
}
