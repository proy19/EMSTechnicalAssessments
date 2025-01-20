using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementSystem.Models
{
    public class EmployeeRoleModel
    {
        [Key]
        public int EmployeeRoleID { get; set; }
        public int EmployeeID { get; set; }
        public int RoleID { get; set; }
    }
}
