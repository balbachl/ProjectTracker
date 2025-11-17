using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProjectTracker.Models
{
    public class Employee
    {
        public int Id { get; set; }
        [DisplayName("First Name")]
        public string FirstName { get; set; } = string.Empty;
        [DisplayName("Last Name")]
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        [DisplayName("Date Hired")]
        public DateTime? HireDate { get; set; }
        
        [DataType(DataType.Currency)]
        public decimal Salary { get; set; }
        [DisplayName("Department")]
        public int DepartmentId { get; set; }
        // Navigation property for related department
        public Department? Department { get; set; }

        // Navigation property for related employee projects
        public ICollection<EmployeeProjects> EmployeeProjects { get; set; } = new List<EmployeeProjects>();
    }
}
