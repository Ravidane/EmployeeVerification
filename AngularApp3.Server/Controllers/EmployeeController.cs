using Microsoft.AspNetCore.Mvc;
using EmployeeModel;
using DataProvider;

namespace AngularApp3.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly EmployeeUnitOfWork _employeeUow;

        public EmployeeController(EmployeeUnitOfWork employeeUnitOfWork)
        {
            _employeeUow = employeeUnitOfWork;
        }

        [Route("verify-employment")]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Employee employeeModel)
        {
            var employee = await _employeeUow.Repository
                .GetEmployeeByIdAsync(employeeModel.EmployeeID);

            return (employee is not null 
                && employee.VerificationCode == employeeModel.VerificationCode)
                ? new JsonResult("Validated")
                : new JsonResult("Invalid");
        }
    }
}
