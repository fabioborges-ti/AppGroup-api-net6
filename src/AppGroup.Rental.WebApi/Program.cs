using AppGroup.Rental.Infrastructure.Database.Context;
using AppGroup.Rental.WebApi;
using AppGroup.Rental.WebApi.Core.Middlewares;
using Asp.Versioning.ApiExplorer;
using Microsoft.EntityFrameworkCore;
using Serilog;

try
{
    var builder = WebApplication.CreateBuilder(args);

    builder.Host.UseSerilog((context, configuration) => configuration.ReadFrom.Configuration(context.Configuration));

    var startup = new Startup(builder.Configuration);

    startup.ConfigureServices(builder.Services);

    var app = builder.Build();

    #region MIGRATIONS

    using (var scope = app.Services.CreateScope())
    {
        var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

        db.Database.Migrate();
    }

    #endregion

    app.UseSerilogRequestLogging();

    app.UseMiddleware<ErrorHandlerMiddleware>();
    app.UseMiddleware<RequestSerilLogMiddleware>();

    var provider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();

    startup.Configure(app, provider);

    app.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "Host terminated unexpectedly");
}
finally
{
    Log.Information("Server Shutting down...");
    Log.CloseAndFlush();
}