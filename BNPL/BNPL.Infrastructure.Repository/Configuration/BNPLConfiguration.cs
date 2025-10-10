using BNPL.Infrastructure.Repository.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace BNPL.Infrastructure.Repository.Configuration;

public partial class BNPLConfiguration
{
    public static void Configure(IServiceCollection services, string dbConnectionString)
    {
        ConfigureDatabase(services, dbConnectionString);
    }

    private static void ConfigureDatabase(IServiceCollection services, string connectionstring)
    {
        services.AddDbContext<BNPLDBContext>(option =>
        {
            option.UseSqlServer(connectionstring,
                b => b.MigrationsAssembly("BNPL.Infrastructure.Repository"));
        }, ServiceLifetime.Scoped);
    }
}

public partial class BNPLConfiguration
{
    public static bool Migrate(IServiceProvider app)
    {
        try
        {
            var servicesScop = app.CreateScope();
            var services = servicesScop.ServiceProvider;
            var context = services.GetRequiredService<BNPLDBContext>();
            context.Database.Migrate();
            servicesScop.Dispose();
            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
    }
}
