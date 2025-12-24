using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ATNewsprimeApp.Migrations
{
    /// <inheritdoc />
    public partial class SeedSuperAdmin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PasswordHash",
                table: "AllAdmins",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AllAdmins",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2025, 12, 8, 13, 0, 22, 901, DateTimeKind.Local).AddTicks(443), "$2a$12$CqYwR1cJ3n8M2uB9dQGxVe1v7Z5Fw2Oj7X2k/sG1B0DdXhRk1t7yG" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PasswordHash",
                table: "AllAdmins");

            migrationBuilder.UpdateData(
                table: "AllAdmins",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 25, 13, 57, 59, 70, DateTimeKind.Local).AddTicks(7990));
        }
    }
}
