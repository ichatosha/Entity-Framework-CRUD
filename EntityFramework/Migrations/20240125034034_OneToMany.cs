using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class OneToMany : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //fluent API
            migrationBuilder.AddColumn<int>(
                name: "departmentId",
                table: "Students",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Students_departmentId",
                table: "Students",
                column: "departmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Departments_departmentId",
                table: "Students",
                column: "departmentId",
                principalTable: "Departments",
                principalColumn: "DepartmentId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Departments_departmentId",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_departmentId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "departmentId",
                table: "Students");
        }
    }
}
