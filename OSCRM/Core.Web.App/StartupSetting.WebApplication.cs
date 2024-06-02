
using Microsoft.EntityFrameworkCore;
using Data.Warehouse.PostgreSQL.OSCRM.DAL;
using Data.Warehouse.PostgreSQL.Rehearsal.DAL;
using Data.Warehouse.PostgreSQL.LakeMaster.DAL;

public static partial class StartupSetting
{
    public static WebApplication? UseWebAppServices(this WebApplication app)
    {
        UseSwagger(app);

        UseResponseCompression(app);

        RunAutomaticMigration<OSCRMDbContext>(app);
        RunAutomaticMigration<RehearsalDbContext>(app);
        RunAutomaticMigration<LakeMasterDbContext>(app);

        return app;
    }

    private static void UseSwagger(WebApplication app)
    {
        app.UseSwagger();
        app.UseSwaggerUI(options => 
        {
            options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
            options.SwaggerEndpoint("/swagger/v2/swagger.json", "v2");
        });
    }

    private static void UseResponseCompression(WebApplication app) => app.UseResponseCompression();

    private static void RunAutomaticMigration<T>(WebApplication app) where T : DbContext
    {
        using var scope = app.Services.GetService<IServiceScopeFactory>()?.CreateScope();
        using var context = scope?.ServiceProvider.GetRequiredService<T>();
        context?.Database.Migrate();
    }
}