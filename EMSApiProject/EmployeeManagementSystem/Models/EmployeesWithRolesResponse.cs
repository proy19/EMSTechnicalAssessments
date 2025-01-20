using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementSystem.Models
{
    public class EmployeesWithRolesResponse
    {
        [Key]
        public int EmployeeID { get; set; }
        public String? FirstName { get; set; }
        public String? LastName { get; set; }
        public int? ManagerID { get; set; }
        public List<string>? Roles { get; set; }

    }
}
