using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class AddGender : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateSequence<int>(
                name: "deliveryOreder",
                startValue: 0L);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Invoices",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 1, 28, 2, 44, 28, 166, DateTimeKind.Local).AddTicks(3431),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 1, 28, 0, 16, 7, 799, DateTimeKind.Local).AddTicks(1548));

            migrationBuilder.AddColumn<string>(
                name: "AuthorGender",
                table: "Books",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Gender",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GenderName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gender", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Gender",
                columns: new[] { "Id", "GenderName" },
                values: new object[,]
                {
                    { 1, " Male" },
                    { 2, "Female" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Gender");

            migrationBuilder.DropColumn(
                name: "AuthorGender",
                table: "Books");

            migrationBuilder.DropSequence(
                name: "deliveryOreder");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Invoices",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 1, 28, 0, 16, 7, 799, DateTimeKind.Local).AddTicks(1548),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 1, 28, 2, 44, 28, 166, DateTimeKind.Local).AddTicks(3431));
        }
    }
}
