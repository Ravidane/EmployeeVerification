using DataProvider.Repositories;

namespace DataProvider.UOW;

public interface IUnitOfWork : IDisposable
{
    Task SaveAsync();
    EmployeeRepository Repository { get; }
}