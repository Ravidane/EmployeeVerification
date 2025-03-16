using EmployeeModel;
using Microsoft.EntityFrameworkCore;

namespace DataProvider;

public class EmployeeDbContext : DbContext
{
    public DbSet<Employee> Employees { get; set; }
    public EmployeeDbContext(DbContextOptions<EmployeeDbContext> options) 
        : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Employee>().HasData(
            new Employee(1, "Company A", "ABC123"),
            new Employee(2, "Company B", "DEF456")
        );
    }
}