namespace DataProvider;

public class EmployeeUnitOfWork : IUnitOfWork
{
    private readonly EmployeeDbContext _context;

    public EmployeeRepository Repository { get; }

    public EmployeeUnitOfWork(EmployeeDbContext context)
    {
        _context = context;
        Repository = new EmployeeRepository(context);
    }

    public async Task SaveAsync()
    {
        await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}