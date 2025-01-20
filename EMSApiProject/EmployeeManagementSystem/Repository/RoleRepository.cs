using EmployeeManagementSystem.Data;
using EmployeeManagementSystem.Interfaces;
using EmployeeManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementSystem.Repository
{
    public class RoleRepository : IRoleRepository
    {
        private readonly ApplicationDbContext _context;
        public RoleRepository(ApplicationDbContext context) {
            _context = context;
        }
        public Task<List<RoleModel>> GetAllRolesAsync()
        {
            return _context.Roles.ToListAsync();
            
        }
    }
}
