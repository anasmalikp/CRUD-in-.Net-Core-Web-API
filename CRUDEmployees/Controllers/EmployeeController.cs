using CRUDEmployees.Model;
using CRUDEmployees.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace CRUDEmployees.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployee employeesReP;
        public EmployeeController(IEmployee eRep)
        {
            employeesReP = eRep;
        }

        [HttpGet]
        public IActionResult employeeget()
        {
            return Ok(employeesReP);
        }

        [HttpPost]
        public IEnumerable<EmployeeModel> emplcreate(EmployeeModel employee)
        {
            return employeesReP.addEmployee(employee);
        }

        [HttpPatch("{id:int}edit")]
        public IEnumerable<EmployeeModel> empledit(int id, JsonPatchDocument<EmployeeModel> employee)
        {
            return employeesReP.editEmployee(id, employee);
        }

        [HttpDelete("delete{id:int}")]
        public IActionResult deleteempl(int id)
        {
            return NoContent();
        }
    }
}
