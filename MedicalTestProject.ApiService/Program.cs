using MedicalTestProject.ApiService.Infrastructure.Database;
using MedicalTestProject.ApiService.Presentation.Extensions;
using MedicalTestProject.ApiService.Presentation.Interceptors;
using MedicalTestProject.ServiceDefaults;

namespace MedicalTestProject.ApiService;

public partial class Program
{
    private static void Main(string[] args)
    {
        WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

        builder.AddNpgsqlDbContext<MedicalContext>("medical");

        IServiceCollection services = builder.Services;
        IConfigurationRoot config = new ConfigurationBuilder()
            .SetBasePath(AppContext.BaseDirectory)
            .AddJsonFile("appsettings.json", false, true)
            .AddJsonFile("appsettings.development.json", true, true)
            .Build();

        services.AddControllers();

        services.AddOpenApiDoc();

        builder.AddServiceDefaults();

        services.AddProblemDetails();

        services.AddOpenApi();

        services.AddExceptionHandler<GlobalExceptionHandler>();

        WebApplication app = builder.Build();

        app.UseExceptionHandler();

        if (app.Environment.IsDevelopment())
        {
            app.UseOpenApi();
            app.UseSwaggerUi();
        }

        app.MapGet("/", () => "API service for MedicalTestProject");

        app.Run();
    }
}
