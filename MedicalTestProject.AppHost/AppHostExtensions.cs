namespace MedicalTestProject.AppHost;

public static class AppHostExtensions
{
    public static IResourceBuilder<PostgresDatabaseResource> AddDatabase
        (this IDistributedApplicationBuilder builder, string user = "admin", string pass = "admin", int port = 5432)
    {
        IResourceBuilder<ParameterResource> dbUser = builder
            .AddParameter("postgres-user", user, secret: true);

        IResourceBuilder<ParameterResource> dbPass = builder
            .AddParameter("postgres-pass", pass, secret: true);

        IResourceBuilder<PostgresDatabaseResource> postgres = builder
            .AddPostgres("postgres", dbUser, dbPass, port)
            //.WithDataVolume()
            .AddDatabase("medical");

        return postgres;
    }
}
