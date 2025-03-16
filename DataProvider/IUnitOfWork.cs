namespace DataProvider;

public interface IUnitOfWork : IDisposable
{
    Task SaveAsync();
    EmployeeRepository Repository { get; }
}