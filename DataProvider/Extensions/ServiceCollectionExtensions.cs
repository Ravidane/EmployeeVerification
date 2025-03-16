using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DataProvider;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddEmployeeDbContext(this IServiceCollection services)
    {
        var connection = new Microsoft.Data.Sqlite.SqliteConnection("DataSource=:memory:");
        connection.Open();

        services.AddDbContext<EmployeeDbContext>(options =>
            options.UseSqlite(connection));

        return services;
    }
}

