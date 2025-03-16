using EmployeeModel;

namespace DataProvider
{
    public interface IEmployeeRepository
    {
        Employee GetEmployeeByIdAsync(long Id) 
            => throw new NotImplementedException();
    }
}
