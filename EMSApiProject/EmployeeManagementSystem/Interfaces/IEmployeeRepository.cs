using EmployeeManagementSystem.Models;

namespace EmployeeManagementSystem.Interfaces
{
    public interface IEmployeeRepository
    {
        List<EmployeesWithRolesResponse> GetAllEmployeesWithRoles();
        Task<List<EmployeeModel>> GetAllManagersAsync();
        List<EmployeesWithRolesResponse> GetEmployeesByManagers(int managerID);
        Task<EmployeeModel> CreateEmployeeAsync(EmployeeRequestModel employeePayload);
    }
}