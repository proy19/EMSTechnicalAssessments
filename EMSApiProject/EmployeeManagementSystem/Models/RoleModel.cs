using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementSystem.Models
{
    public class RoleModel
    {
        [Key]
        public int RoleID { get; set; }
        public String? RoleName { get; set; }
    }
}
