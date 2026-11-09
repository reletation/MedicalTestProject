namespace MedicalTestProject.ApiService.Infrastructure.Options;

public class ConnectionOptions
{
    public PostgresOptions MedicalConnection { get; set; } = new();
}
