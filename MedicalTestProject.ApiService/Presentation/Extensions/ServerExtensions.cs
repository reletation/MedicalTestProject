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
            doc.ApiGroupNames = ["main"];
        });

        return services;
    }
}
