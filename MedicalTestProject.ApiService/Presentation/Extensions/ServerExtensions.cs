using MedicalTestProject.ApiService.Application.Repositories;
using MedicalTestProject.ApiService.Application.Services;
using MedicalTestProject.ApiService.Infrastructure.Repositories;
using MedicalTestProject.ApiService.Infrastructure.Services;

namespace MedicalTestProject.ApiService.Presentation.Extensions;

public static class ServerExtensions
{
    public static IServiceCollection AddOpenApiDoc
        (this IServiceCollection services)
    {
        services.AddOpenApiDocument(doc =>
        {
            doc.Title = "Medical API";
            doc.Version = "v1";
            doc.DocumentName = "Medical API";
        });

        return services;
    }


    public static IServiceCollection AddServices
        (this IServiceCollection services)
    {
        services.AddScoped<IPatientService, PatientService>()
                .AddScoped<IDiseaseService, DiseaseService>()
                .AddScoped<IDoctorService, DoctorService>();

        return services;
    }
    
    public static IServiceCollection AddRepositories
        (this IServiceCollection services)
    {
        services.AddScoped<IPatientReadRepository, PatientReadRepository>()
                .AddScoped<IDiseaseReadRepository, DiseaseReadRepository>()
                .AddScoped<IDoctorReadRepository, DoctorReadRepository>();

        return services;
    }

}
