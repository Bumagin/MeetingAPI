using Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Persistence;

public static class DependencyInjection
{
    public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration["PostgreSQL"];
        services.AddDbContext<MeetingDbContext>(options =>
        {
            options.UseNpgsql(connectionString);
        });
        services.AddScoped<IUserDbContext>(provider =>
            provider.GetService<MeetingDbContext>());
        return services;
    }
}   