using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Data.Context;

namespace Data.DI;

public static class DbContextRegister
{
    public static IServiceCollection RegisterDbContext(this IServiceCollection services, string ConStr)
    {
        services.AddDbContext<FitGoalContext>(options =>
           options.UseMySql(ConStr, new MySqlServerVersion(new Version(8, 0, 30))));

        return services;
    }
}

