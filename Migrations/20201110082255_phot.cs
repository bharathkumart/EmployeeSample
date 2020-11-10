using Microsoft.EntityFrameworkCore.Migrations;

namespace EmployeeSample.Migrations
{
    public partial class phot : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Photopath",
                table: "Employees",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Department", "Email", "Name", "Photopath" },
                values: new object[] { 2, 1, "rajesd@gmail.com", "Rajesh", null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DropColumn(
                name: "Photopath",
                table: "Employees");
        }
    }
}
