namespace PlatformService.Data;

public static class PreperationData
{
    public static void PopulationData(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();

        SeedData(scope.ServiceProvider.GetRequiredService<AppDbContext>(), app.Logger);
    }

    private static void SeedData(AppDbContext context, ILogger logger)
    {
        if (!context.Platforms.Any())
        {
            List<Platform> platforms = new()
            {
                new(){Name="Dotnet",Publisher="Microsoft",Cost="Free"},
                new(){Name="Sql Server Crack",Publisher="Microsoft",Cost="Free"},
                new(){Name="Kubernetes",Publisher="Cloud Native Computing Fundation",Cost="Free"},
                new(){Name="Git",Publisher="Open Sourse Fundation",Cost="Free"}
            };

            context.Platforms.AddRange(platforms);

            var saveStatus = context.SaveChanges();
            if (saveStatus >= 0)
                logger.LogInformation("Platform Seed Data has Success!");
            else
                logger.LogInformation("Platform Seed Data has Failure!");

        }
        else
            logger.LogInformation("Platform has already data");
    }
}