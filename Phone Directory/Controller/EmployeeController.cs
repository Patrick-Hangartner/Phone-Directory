using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Phone_Directory.Models;
using PhoneDirectory.Data;

namespace PhoneDirectory.Controllers
{
    [EnableCors("AllowSpecificOrigin")]
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        public ActionResult<List<Employee>> GetAllEmployees()
        {
            var employees = _employeeService.GetAllEmployees();
            return Ok(employees);
        }

        [HttpGet("search")]
        public ActionResult<List<Employee>> SearchEmployees(string searchTerm)
        {
            var employees = _employeeService.SearchEmployees(searchTerm);
            return Ok(employees);
        }
        [HttpPost]
        public IActionResult Insert(AddEmployee employee)
        {
            _employeeService.InsertEmployee(employee);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Employee employee)
        {
            _employeeService.UpdateEmployee(employee);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _employeeService.DeleteEmployee(id);
            return Ok();
        }
    }

}

