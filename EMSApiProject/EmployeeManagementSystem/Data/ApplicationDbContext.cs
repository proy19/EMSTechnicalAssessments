using EmployeeManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementSystem.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<RoleModel> Roles { get; set; }
        public DbSet<EmployeeModel> Employees { get; set; }
        public DbSet<EmployeeRoleModel> EmployeeRoles { get; set; }

    }
}
