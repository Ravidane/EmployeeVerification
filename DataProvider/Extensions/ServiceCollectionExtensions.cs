using DataProvider.DatabaseContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DataProvider;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddEmployeeDbContext(
        this IServiceCollection services, IConfigurationRoot configuration)
    {
        var connection = new Microsoft.Data.Sqlite.SqliteConnection(configuration.GetConnectionString("Sqlite"));
        connection.Open();

        services.AddDbContext<EmployeeDbContext>(options =>
            options.UseSqlite(connection));

        return services;
    }
}

