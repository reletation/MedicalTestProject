using MedicalTestProject.ApiService.Infrastructure.Database;
using MedicalTestProject.MigrationService.Seeding;
using MedicalTestProject.ServiceDefaults;

namespace MedicalTestProject.MigrationService;

public partial class Program
{
    private static void Main(string[] args)
    {
        HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);

        builder.AddServiceDefaults();
        builder.Services.AddHostedService<Worker>();

        builder.AddNpgsqlDbContext<MedicalContext>("medical",
            configureDbContextOptions: options =>
            {
                options.UseSeeding((context, _) =>
                {
                    if (context is MedicalContext medicalContext)
                        medicalContext.SeedData();
                });

                options.UseAsyncSeeding(async (context, _, cancellationToken) =>
                {
                    if (context is MedicalContext medicalContext)
                        await medicalContext.SeedDataAsync(cancellationToken);
                });
            });

        IHost host = builder.Build();
        host.Run();
    }
}