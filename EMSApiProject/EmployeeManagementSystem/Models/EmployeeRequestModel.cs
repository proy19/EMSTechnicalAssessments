namespace EmployeeManagementSystem.Models
{
    public class EmployeeRequestModel
    {
        public String? FirstName { get; set; }
        public String? LastName { get; set; }
        public int? ManagerID { get; set; }
        public List<int>? RoleIDList { get; set; }
    }
}