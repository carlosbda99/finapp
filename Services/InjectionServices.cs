using Finapp.Repository;
using Finapp.Repository.Context;
using Finapp.Repository.Interfaces;
using Finapp.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Finapp.Services;

public static class InjectionServices
{
    public static IServiceCollection AddServices(
        this IServiceCollection services,
        IConfiguration configuration
    )
    {
        // DbContext
        services.AddDbContext<FinappContext>(
            options =>
                options.UseSqlite(configuration.GetConnectionString("FinApp"))
        );

        // Repositories
        services.AddTransient<IBillRepository, BillRepository>();
        services.AddTransient<IUnitOfWork, UnitOfWork>();

        // Services
        services.AddTransient<IBillService, BillService>();

        return services;
    }
}