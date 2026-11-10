using FluentValidation;
using MedicalTestProject.ApiService.Application.Repositories;
using MedicalTestProject.ApiService.Application.Services;
using MedicalTestProject.ApiService.Infrastructure.Database;
using MedicalTestProject.ApiService.Infrastructure.Repositories;
using MedicalTestProject.ApiService.Infrastructure.Services;
using MedicalTestProject.ApiService.Presentation.Extensions;
using MedicalTestProject.ApiService.Presentation.Interceptors;
using MedicalTestProject.ServiceDefaults;
using SharpGrip.FluentValidation.AutoValidation.Mvc.Extensions;

namespace MedicalTestProject.ApiService;

public partial class Program
{
    private static void Main(string[] args)
    {
        WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

        builder.AddNpgsqlDbContext<MedicalContext>("medical");

        IServiceCollection services = builder.Services;
        IConfigurationManager config = builder.Configuration;

        config.SetBasePath(AppContext.BaseDirectory)
              .AddJsonFile("appsettings.json", false, true)
              .AddJsonFile("appsettings.development.json", true, true);

        services.AddControllers();

        services.AddOpenApiDoc();

        builder.AddServiceDefaults();

        services.AddProblemDetails();

        services.AddOpenApi();

        services.AddExceptionHandler<DomainExceptionHandler>()
                .AddExceptionHandler<ApplicationExceptionHandler>()
                .AddExceptionHandler<GlobalExceptionHandler>();

        services.AddRepositories()
                .AddServices();

        services.AddValidatorsFromAssemblyContaining<Program>();
        services.AddFluentValidationAutoValidation();

        WebApplication app = builder.Build();

        app.UseExceptionHandler();

        if (app.Environment.IsDevelopment())
        {
            app.UseOpenApi();
            app.UseSwaggerUi();
        }

        app.MapGet("/", () => "API service for MedicalTestProject");
        app.MapControllers();

        app.Run();
    }
}
