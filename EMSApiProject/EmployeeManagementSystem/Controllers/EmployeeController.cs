using EmployeeManagementSystem.Interfaces;
using EmployeeManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        [HttpGet("employees-with-roles")]
        public ActionResult<List<EmployeesWithRolesResponse>> GetAllEmployeeWithRoles()
        {
            var employeeWithroles = _employeeRepository.GetAllEmployeesWithRoles();
            return Ok(employeeWithroles);
        }


        [HttpGet("managers")]
        public async Task<IActionResult> GetAllManagers()
        {
            var managers = await _employeeRepository.GetAllManagersAsync();
            return Ok(managers);
        }

        [HttpGet("employees-by-manager/{managerID}")]
        public ActionResult<List<EmployeesWithRolesResponse>> GetAllEmployeesByManagers(int managerID)
        {
            var employeesByManager = _employeeRepository.GetEmployeesByManagers(managerID);
            return Ok(employeesByManager);
        }


        [HttpPost("create-employee")]
        public async Task<IActionResult> CreateEmployee([FromBody] EmployeeRequestModel payload)
        {
            var createdEmployee = await _employeeRepository.CreateEmployeeAsync(payload);
            return Ok(createdEmployee);
        }
    }
}
