using Microsoft.AspNetCore.Mvc;
using DataProvider.UOW;
using EmployeeVerification.Server.ViewModels;

namespace EmployeeVerification.Server.Controllers;

[ApiController]
[Route("api")]  
public class EmployeeController(EmployeeUnitOfWork employeeUnitOfWork) 
    : ControllerBase
{
    [Route("verify-employment")]
    [HttpPost()]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Post([FromBody] EmployeeViewModel employeeModel)
    {
        var employee = await employeeUnitOfWork.Repository
            .GetEmployeeByIdAsync(employeeModel.EmployeeID);

        return (employee is not null
            && employee.ValidationCode == employeeModel.ValidationCode)
            ? new OkResult()
            : new NotFoundResult();
    }
}
