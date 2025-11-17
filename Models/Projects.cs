using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProjectTracker.Models
{
    public class Projects
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        
        [DisplayName("Start Date")]
        public DateTime? StartDate { get; set; }
        
        [DisplayName("Completion Date")]
        public DateTime? EndDate { get; set; }
        
        [DataType(DataType.Currency)]
        public decimal Budget { get; set; }
        
        [DisplayName("Department")]
        public int DepartmentId { get; set; }
        // Navigation property for related department
        public Department? Department { get; set; }

        // Navigation property for related employee projects
        public ICollection<EmployeeProjects> EmployeeProjects { get; set; } = new List<EmployeeProjects>();
    }
}
