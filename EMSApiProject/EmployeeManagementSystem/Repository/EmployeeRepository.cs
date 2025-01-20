using EmployeeManagementSystem.Data;
using EmployeeManagementSystem.Interfaces;
using EmployeeManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementSystem.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ApplicationDbContext _context;
        public EmployeeRepository(ApplicationDbContext context) {
            _context = context;
        }
        public List<EmployeesWithRolesResponse> GetAllEmployeesWithRoles()
        {
            var employeesWithRoles = _context.Employees.
                Select(employee => new EmployeesWithRolesResponse
                {
                    EmployeeID = employee.EmployeeID,
                    FirstName = employee.FirstName,
                    LastName = employee.LastName,
                    ManagerID = employee.ManagerID,
                    Roles = _context.EmployeeRoles
                        .Where(empRole => empRole.EmployeeID == employee.EmployeeID)
                        .Join(_context.Roles,
                            empRole => empRole.RoleID,
                            role => role.RoleID,
                            (empRole, role) => role.RoleName
                        ).ToList()
                }).ToList();

            return employeesWithRoles;
        }

        public async Task<List<EmployeeModel>> GetAllManagersAsync()
        {
            var managers = await _context.Employees
                .Where(employee => _context.Employees.Any(emp => emp.ManagerID == employee.EmployeeID))
                .Distinct()
                .Select(m => new EmployeeModel
                {
                    EmployeeID = m.EmployeeID,
                    FirstName = m.FirstName,
                    LastName = m.LastName,
                    ManagerID = m.ManagerID,
                })
                .ToListAsync();
            return managers;
        }

        public List<EmployeesWithRolesResponse> GetEmployeesByManagers(int managerID)
        {
            var employeesByManager = _context.Employees.
                Where(employee => employee.ManagerID == managerID)
                .Select(employee => new EmployeesWithRolesResponse
                {
                    EmployeeID = employee.EmployeeID,
                    FirstName = employee.FirstName,
                    LastName = employee.LastName,
                    ManagerID = employee.ManagerID,
                    Roles = _context.EmployeeRoles
                        .Where(empRole => empRole.EmployeeID == employee.EmployeeID)
                        .Join(_context.Roles,
                            empRole => empRole.RoleID,
                            role => role.RoleID,
                            (empRole, role) => role.RoleName
                        ).ToList()
                }).ToList();

            return employeesByManager;

        }

        public async Task<EmployeeModel> CreateEmployeeAsync(EmployeeRequestModel employeePayload)
        {
            var newEmployee = new EmployeeModel
            {
                FirstName = employeePayload.FirstName,
                LastName = employeePayload.LastName,
                ManagerID = employeePayload.ManagerID,
            };

            await _context.Employees.AddAsync(newEmployee);
            await _context.SaveChangesAsync();

            var newEmployeeRole = employeePayload.RoleIDList.Select(roleId => new EmployeeRoleModel
            {
                EmployeeID = newEmployee.EmployeeID,
                RoleID = roleId
            }).ToList();

            await _context.EmployeeRoles.AddRangeAsync(newEmployeeRole);
            await _context.SaveChangesAsync();

            return newEmployee;
        }
    }
}
