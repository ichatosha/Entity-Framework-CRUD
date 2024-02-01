using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class AddInvoice : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Grades_Students_StudentId",
                table: "Grades");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentBooks_Books_bookId",
                table: "StudentBooks");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentBooks_Students_StudentId",
                table: "StudentBooks");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_Departments_departmentId",
                table: "Students");

            migrationBuilder.EnsureSchema(
                name: "schem");

            migrationBuilder.CreateTable(
                name: "atts",
                schema: "schem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameOfDay = table.Column<string>(type: "varchar(50)", nullable: false),
                    StudentName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    studentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_atts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_atts_Students_studentId",
                        column: x => x.studentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Invoices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DescriptionName = table.Column<string>(type: "nvarchar(max)", nullable: false, computedColumnSql: "[CustomerTitle] + ' ' + [CustomerName]"),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Qty = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    total = table.Column<decimal>(type: "decimal(18,2)", nullable: false, computedColumnSql: "[Qty] * [Price]"),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2024, 1, 28, 0, 16, 7, 799, DateTimeKind.Local).AddTicks(1548))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoices", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_atts_studentId",
                schema: "schem",
                table: "atts",
                column: "studentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Grades_Students_StudentId",
                table: "Grades",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentBooks_Books_bookId",
                table: "StudentBooks",
                column: "bookId",
                principalTable: "Books",
                principalColumn: "BookId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentBooks_Students_StudentId",
                table: "StudentBooks",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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
                name: "FK_Grades_Students_StudentId",
                table: "Grades");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentBooks_Books_bookId",
                table: "StudentBooks");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentBooks_Students_StudentId",
                table: "StudentBooks");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_Departments_departmentId",
                table: "Students");

            migrationBuilder.DropTable(
                name: "atts",
                schema: "schem");

            migrationBuilder.DropTable(
                name: "Invoices");

            migrationBuilder.AddForeignKey(
                name: "FK_Grades_Students_StudentId",
                table: "Grades",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentBooks_Books_bookId",
                table: "StudentBooks",
                column: "bookId",
                principalTable: "Books",
                principalColumn: "BookId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentBooks_Students_StudentId",
                table: "StudentBooks",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Departments_departmentId",
                table: "Students",
                column: "departmentId",
                principalTable: "Departments",
                principalColumn: "DepartmentId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
