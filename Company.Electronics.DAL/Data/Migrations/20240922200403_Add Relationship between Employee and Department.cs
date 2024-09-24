using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Company.Electronics.DAL.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddRelationshipbetweenEmployeeandDepartment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "WorkforId",
                table: "Employees",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_WorkforId",
                table: "Employees",
                column: "WorkforId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Department_WorkforId",
                table: "Employees",
                column: "WorkforId",
                principalTable: "Department",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Department_WorkforId",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_WorkforId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "WorkforId",
                table: "Employees");
        }
    }
}
