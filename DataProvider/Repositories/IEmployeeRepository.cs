using DomainModels;

namespace DataProvider.Repositories
{
    public interface IEmployeeRepository
    {
        Employee GetEmployeeByIdAsync(long Id)
            => throw new NotImplementedException();
    }
}
