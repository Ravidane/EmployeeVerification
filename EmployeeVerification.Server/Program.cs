using DataProvider;
using DataProvider.DatabaseContexts;
using DataProvider.UOW;
using EmployeeVerification.Server.Middleware;
using Microsoft.EntityFrameworkCore;

namespace EmployeeVerification.Server;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddEmployeeDbContext(builder.Configuration);

        builder.Services.AddScoped<EmployeeUnitOfWork>();
        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
            app.UseDeveloperExceptionPage();
        }

        using (var scope = app.Services.CreateScope())
        {
            var dbContext = scope.ServiceProvider.GetRequiredService<EmployeeDbContext>();
            dbContext.Database.OpenConnection();
            dbContext.Database.EnsureCreated(); 
        }

        app.UseMiddleware<ExceptionHandler>();
        app.UseHttpsRedirection();
        app.MapControllers();

        app.Run();
    }
}