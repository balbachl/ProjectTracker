using System.ComponentModel;

namespace ProjectTracker.Models
{
    public class EmployeeProjects
    {
        [DisplayName("Employee")]
        public int EmployeeId { get; set; }
        public Employee? Employee { get; set; }
        [DisplayName("Project")]
        public int ProjectId { get; set; }
        public Projects? Project { get; set; }
    }
}
