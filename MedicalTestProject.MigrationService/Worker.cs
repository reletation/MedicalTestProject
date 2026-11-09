using MedicalTestProject.ApiService.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace MedicalTestProject.MigrationService;

public class Worker(
    IServiceProvider serviceProvider,
    IHostApplicationLifetime lifetime) : BackgroundService
{
    protected override async Task ExecuteAsync
        (CancellationToken stoppingToken)
    {
        using IServiceScope scope = serviceProvider.CreateScope();

        DbContext context = scope.ServiceProvider.GetRequiredService<MedicalContext>();

        await context.Database.MigrateAsync(stoppingToken);

        lifetime.StopApplication();
    }
}
