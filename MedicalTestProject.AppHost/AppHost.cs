using Projects;

namespace MedicalTestProject.AppHost;

public partial class Program
{
    private static void Main(string[] args)
    {
        IDistributedApplicationBuilder builder = DistributedApplication.CreateBuilder(args);

        IResourceBuilder<PostgresDatabaseResource> postgres = builder.AddDatabase();

        IResourceBuilder<ProjectResource> migrations = builder
            .AddProject<MedicalTestProject_MigrationService>("migrations")
            .WithReference(postgres)
            .WaitFor(postgres);

        builder.AddProject<MedicalTestProject_ApiService>("api")
               .WithReference(postgres)
               .WaitForCompletion(migrations);

        DistributedApplication app = builder.Build();

        app.Run();
    }
}

