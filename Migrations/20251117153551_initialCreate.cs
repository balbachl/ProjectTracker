using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ProjectTracker.Migrations
{
    /// <inheritdoc />
    public partial class initialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HireDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Salary = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employees_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Budget = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Projects_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeProjects",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    ProjectId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeProjects", x => new { x.EmployeeId, x.ProjectId });
                    table.ForeignKey(
                        name: "FK_EmployeeProjects_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EmployeeProjects_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Location", "Name" },
                values: new object[,]
                {
                    { 1, "Downtown", "Human Resources" },
                    { 2, "Remote", "IT" },
                    { 3, "Downtown", "Finance" },
                    { 4, "Remote", "Marketing" },
                    { 5, "Satellite", "Sales" },
                    { 6, "Warehouse District", "Plant" },
                    { 7, "Warehouse District", "Shipping" },
                    { 8, "Warehouse District", "Receiving" },
                    { 9, "Warehouse District", "Warehouse" }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "DepartmentId", "Email", "FirstName", "HireDate", "LastName", "Salary" },
                values: new object[,]
                {
                    { 1, 2, "johndoe@acme.com", "John", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Doe", 60000m },
                    { 2, 3, "janesmith@acme.com", "Jane", new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Smith", 65000m },
                    { 3, 4, "alicejohnson@acme.com", "Alice", new DateTime(2025, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Johnson", 70000m },
                    { 4, 5, "bobbrown@acme.com", "Bob", new DateTime(2024, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Brown", 55000m },
                    { 5, 1, "charliedavis@acme.com", "Charlie", new DateTime(2025, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Davis", 50000m },
                    { 6, 6, "evewilson@acme.com", "Eve", new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Wilson", 72000m },
                    { 7, 7, "frankie@acme.com", "Frank", new DateTime(2019, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Miller", 58000m },
                    { 8, 8, "gracetaylor@acme.com", "Grace", new DateTime(2019, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Taylor", 62000m },
                    { 9, 9, "hankanderson@acme.com", "Hank", new DateTime(2019, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Anderson", 64000m }
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "Budget", "DepartmentId", "Description", "EndDate", "Name", "StartDate" },
                values: new object[,]
                {
                    { 1, 100000m, 4, "New brand for Acme", new DateTime(2026, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rebranding", new DateTime(2025, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 75000m, 3, "Auditing of assets", new DateTime(2025, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Audit", new DateTime(2024, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, 50000m, 2, "Creation of e-commerce website", new DateTime(2025, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Website", new DateTime(2025, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, 20000m, 1, "Orientation program for new hires", new DateTime(2026, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "New Hire Orientation", new DateTime(2025, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, 60000m, 9, "New inventory management system", new DateTime(2028, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Inventory System", new DateTime(2025, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, 80000m, 5, "Implementing a new CRM system", new DateTime(2027, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "CRM Implementation", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "EmployeeProjects",
                columns: new[] { "EmployeeId", "ProjectId" },
                values: new object[,]
                {
                    { 1, 3 },
                    { 2, 2 },
                    { 3, 1 },
                    { 4, 6 },
                    { 5, 4 },
                    { 6, 5 },
                    { 7, 6 },
                    { 8, 1 },
                    { 9, 5 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeProjects_ProjectId",
                table: "EmployeeProjects",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_DepartmentId",
                table: "Employees",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_DepartmentId",
                table: "Projects",
                column: "DepartmentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeProjects");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "Departments");
        }
    }
}
