using EmployeeManagementSystem.Models;

namespace EmployeeManagementSystem.Interfaces
{
    public interface IRoleRepository
    {
        Task<List<RoleModel>> GetAllRolesAsync();
    }
}
