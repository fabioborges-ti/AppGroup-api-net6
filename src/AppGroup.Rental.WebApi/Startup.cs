using AppGroup.Rental.Application.Extensions;
using AppGroup.Rental.Infrastructure.Database.Extensions;
using AppGroup.Rental.WebApi.Extensions;
using AppGroup.Rental.WebApi.Filters;
using AppGroup.Rental.WebApi.Middlewares;
using AppGroup.Rental.WebApi.Swagger;
using Asp.Versioning;
using Asp.Versioning.ApiExplorer;
using Asp.Versioning.Conventions;
using FluentValidation.AspNetCore;
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.SwaggerUI;
using System.Reflection;
using System.Text.Json.Serialization;

namespace AppGroup.Rental.WebApi;

public class Startup
{
    private IConfiguration Configuration { get; }

    public Startup(IConfiguration configuration) => Configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddApplication()
                .AddInfrastructure(Configuration)
                .ConfigureHealthCheck(Configuration)
                .AddProducersAndConsumers(Configuration);

        services.AddHttpContextAccessor();

        services.AddControllersWithViews(options => options.Filters.Add<ApiExceptionFilterAttribute>())
                .AddJsonOptions(options => options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));

        services.Configure<ApiBehaviorOptions>(options => options.SuppressModelStateInvalidFilter = true);

        services
            .AddApiVersioning(options =>
            {
                options.DefaultApiVersion = new ApiVersion(1.0);
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.ReportApiVersions = true;
                options.ApiVersionReader = ApiVersionReader.Combine
                (
                    new UrlSegmentApiVersionReader(),
                    new QueryStringApiVersionReader("api-version"),
                    new HeaderApiVersionReader("X-Version"),
                    new MediaTypeApiVersionReader("x-version")
                );
            })
            .AddMvc(options => options.Conventions.Add(new VersionByNamespaceConvention()))
            .AddApiExplorer(setup =>
            {
                setup.GroupNameFormat = "'v'VVV";
                setup.SubstituteApiVersionInUrl = true;
            });

        services.Configure<KeyManagementOptions>(Configuration);

        services.AddFluentValidationAutoValidation();

        services.AddDatabaseDeveloperPageExceptionFilter();

        services.ConfigureOptions<ConfigureSwaggerOptions>();

        services.AddSwaggerGen(options =>
        {
            var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
        });

        services.AddEndpointsApiExplorer();
    }

    public void Configure(IApplicationBuilder app, IApiVersionDescriptionProvider provider)
    {
        app.UseSwagger();

        app.UseSwaggerUI(options =>
        {
            foreach (var description in provider.ApiVersionDescriptions.Select(p => p.GroupName))
            {
                options.SwaggerEndpoint($"/swagger/{description}/swagger.json", description.ToUpperInvariant());
            }

            options.DocExpansion(DocExpansion.List);
        });

        app.UseRequestLogging();
        app.UseRequestErrors();

        app.UseExceptionHandler("/error");

        app.UseHsts();

        app.UseHealthChecks("/health", new HealthCheckOptions()
        {
            Predicate = _ => true,
            ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse,
        });

        app.UseHttpsRedirection();
        app.UseRouting();

        app.UseAuthentication();
        app.UseAuthorization();

        app.UseCors(policy => policy
          .AllowAnyHeader()
          .AllowAnyMethod()
          .SetIsOriginAllowed(origin => true)
          .AllowCredentials());

        app.UseEndpoints(endpoints => endpoints.MapControllerRoute(name: "default", pattern: "{controller}/{action=Index}/{id?}"));
    }
}
