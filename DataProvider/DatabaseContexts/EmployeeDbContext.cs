using DomainModels;
using Microsoft.EntityFrameworkCore;

namespace DataProvider.DatabaseContexts;

public class EmployeeDbContext(DbContextOptions<EmployeeDbContext> options) 
    : DbContext(options)
{
    public DbSet<Employee> Employees { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Employee>().HasData(
            new Employee(1, "Apple", "ABC123"),
            new Employee(2, "Books", "DEF456")
        );
    }
}