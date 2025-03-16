using DataProvider;
using Microsoft.EntityFrameworkCore;

namespace AngularApp3.Server;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddEmployeeDbContext();

        builder.Services.AddScoped<EmployeeUnitOfWork>();
        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddCors(options =>
        {
            options.AddPolicy("AllowAll", builder =>
            {
                builder.AllowAnyOrigin() 
                       .AllowAnyMethod() 
                       .AllowAnyHeader();
            });
        });
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        app.UseDefaultFiles();
        app.UseStaticFiles();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        using (var scope = app.Services.CreateScope())
        {
            var dbContext = scope.ServiceProvider.GetRequiredService<EmployeeDbContext>();
            dbContext.Database.OpenConnection();
            dbContext.Database.EnsureCreated(); 
        }

        app.UseCors("AllowAll");

        app.UseHttpsRedirection();
        app.Use(async (context, next) =>
        {
            if (context.Request.Path.StartsWithSegments("/api"))
            {
                context.Request.Path = context.Request.Path.Value!.Substring(4);
            }
            await next();
        });
        app.MapControllers();
        app.MapFallbackToFile("/index.html");

        app.Run();
    }
}