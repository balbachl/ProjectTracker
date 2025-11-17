using Microsoft.EntityFrameworkCore;

namespace ProjectTracker.Models
{
    public class ProjectTrackerContext : DbContext
    {
        public ProjectTrackerContext(DbContextOptions<ProjectTrackerContext> options)
            : base(options)
        {
        }
        public DbSet<Department> Departments { get; set; } = null!;
        public DbSet<Employee> Employees { get; set; } = null!;
        public DbSet<Projects> Projects { get; set; } = null!;
        public DbSet<EmployeeProjects> EmployeeProjects { get; set; } = null!;
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure many-to-many relationship between Employee and Projects via EmployeeProjects
            modelBuilder.Entity<EmployeeProjects>()
                .HasKey(ep => new { ep.EmployeeId, ep.ProjectId });
            modelBuilder.Entity<EmployeeProjects>()
                .HasOne(ep => ep.Employee)
                .WithMany(e => e.EmployeeProjects)
                .HasForeignKey(ep => ep.EmployeeId)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<EmployeeProjects>()
                .HasOne(ep => ep.Project)
                .WithMany(p => p.EmployeeProjects)
                .HasForeignKey(ep => ep.ProjectId)
                .OnDelete(DeleteBehavior.NoAction);  

            modelBuilder.Entity<Department>().HasData(
                new Department { Id = 1, Name = "Human Resources", Location="Downtown" },
                new Department { Id = 2, Name = "IT", Location = "Remote" },
                new Department { Id = 3, Name = "Finance", Location = "Downtown" },
                new Department { Id = 4, Name = "Marketing", Location = "Remote" },
                new Department { Id = 5, Name = "Sales", Location = "Satellite" },
                new Department { Id = 6, Name = "Plant", Location = "Warehouse District" },
                new Department { Id = 7, Name = "Shipping", Location = "Warehouse District" },
                new Department { Id = 8, Name = "Receiving", Location = "Warehouse District" },
                new Department { Id = 9, Name = "Warehouse", Location = "Warehouse District" }
            );
            modelBuilder.Entity<Projects>().HasData(
                new Projects { Id = 1, Name = "Rebranding", Description = "New brand for Acme", Budget = 100000, DepartmentId = 4, StartDate = new DateTime(2025, 10, 10), EndDate = new DateTime(2026, 10, 10) },
                new Projects { Id = 2, Name = "Audit", Description = "Auditing of assets",  Budget = 75000, DepartmentId = 3, StartDate = new DateTime(2024, 07, 01), EndDate = new DateTime(2025, 12, 1) },
                new Projects { Id = 3, Name = "Website", Description = "Creation of e-commerce website",  Budget = 50000, DepartmentId = 2, StartDate = new DateTime(2025, 03, 1), EndDate = new DateTime(2025, 12, 1) },
                new Projects { Id = 4, Name = "New Hire Orientation", Description = "Orientation program for new hires",  Budget = 20000, DepartmentId = 1, StartDate = new DateTime(2025, 10, 10), EndDate = new DateTime(2026, 10, 10) },
                new Projects { Id = 5, Name = "Inventory System", Description = "New inventory management system",  Budget = 60000, DepartmentId = 9, StartDate = new DateTime(2025, 1, 10), EndDate = new DateTime(2028, 10, 10) },
                new Projects { Id = 6, Name = "CRM Implementation", Description = "Implementing a new CRM system",  Budget = 80000, DepartmentId = 5, StartDate = new DateTime(2025, 1, 1), EndDate = new DateTime(2027, 10, 10) }
                );
            modelBuilder.Entity<Employee>().HasData(
                new Employee { Id = 1, FirstName = "John", LastName = "Doe", Email = "johndoe@acme.com",  Salary = 60000, DepartmentId = 2, HireDate = new DateTime(2024, 1, 1) },
                new Employee { Id = 2, FirstName = "Jane", LastName = "Smith", Email = "janesmith@acme.com",  Salary = 65000, DepartmentId = 3, HireDate = new DateTime(2023, 10, 1) },
                new Employee { Id = 3, FirstName = "Alice", LastName = "Johnson", Email = "alicejohnson@acme.com", Salary = 70000, DepartmentId = 4, HireDate = new DateTime(2025, 3, 3) },
                new Employee { Id = 4, FirstName = "Bob", LastName = "Brown", Email = "bobbrown@acme.com", Salary = 55000, DepartmentId = 5, HireDate = new DateTime(2024, 8, 1) },
                new Employee { Id = 5, FirstName = "Charlie", LastName = "Davis", Email = "charliedavis@acme.com",  Salary = 50000, DepartmentId = 1, HireDate = new DateTime(2025, 7, 1) },
                new Employee { Id = 6, FirstName = "Eve", LastName = "Wilson", Email = "evewilson@acme.com",  Salary = 72000, DepartmentId = 6, HireDate = new DateTime(2020, 1, 1) },
                new Employee { Id = 7, FirstName = "Frank", LastName = "Miller", Email = "frankie@acme.com", Salary = 58000, DepartmentId = 7, HireDate = new DateTime(2019, 4, 1) },
                new Employee { Id = 8, FirstName = "Grace", LastName = "Taylor", Email = "gracetaylor@acme.com",  Salary = 62000, DepartmentId = 8, HireDate = new DateTime(2019, 5, 1) },
                new Employee { Id = 9, FirstName = "Hank", LastName = "Anderson", Email = "hankanderson@acme.com",  Salary = 64000, DepartmentId = 9, HireDate = new DateTime(2019, 8, 1) }
                );
            modelBuilder.Entity<EmployeeProjects>().HasData(
                new EmployeeProjects { EmployeeId = 1, ProjectId = 3 },
                new EmployeeProjects { EmployeeId = 2, ProjectId = 2 },
                new EmployeeProjects { EmployeeId = 3, ProjectId = 1 },
                new EmployeeProjects { EmployeeId = 4, ProjectId = 6 },
                new EmployeeProjects { EmployeeId = 5, ProjectId = 4 },
                new EmployeeProjects { EmployeeId = 6, ProjectId = 5 },
                new EmployeeProjects { EmployeeId = 7, ProjectId = 6 },
                new EmployeeProjects { EmployeeId = 8, ProjectId = 1 },
                new EmployeeProjects { EmployeeId = 9, ProjectId = 5 }
                );
        }
    }
}
