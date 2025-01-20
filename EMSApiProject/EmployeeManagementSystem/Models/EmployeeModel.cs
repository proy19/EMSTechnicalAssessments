using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementSystem.Models
{
    public class EmployeeModel
    {
        [Key]
        public int EmployeeID { get; set; }
        public String? FirstName { get; set; }
        public String? LastName { get; set; }
        public int? ManagerID { get; set; }
       
    }
}
