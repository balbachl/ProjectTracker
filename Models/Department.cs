namespace ProjectTracker.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        // Navigation property for related employees
        public ICollection<Employee> Employees { get; set; } = new List<Employee>();
        
        // Constructor to initialize the collection
        public Department()
        {
            Employees = new List<Employee>();
        }
    }
}
