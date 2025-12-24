using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ATNewsprimeApp.Migrations
{
    /// <inheritdoc />
    public partial class AddPhoneNumberToAdmin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EmailOrPhone",
                table: "ForgotPassword",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Otp",
                table: "ForgotPassword",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "AllAdmins",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AllAdmins",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PhoneNumber" },
                values: new object[] { new DateTime(2025, 12, 11, 14, 58, 35, 127, DateTimeKind.Local).AddTicks(4508), "9999999999" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmailOrPhone",
                table: "ForgotPassword");

            migrationBuilder.DropColumn(
                name: "Otp",
                table: "ForgotPassword");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "AllAdmins");

            migrationBuilder.UpdateData(
                table: "AllAdmins",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 10, 12, 45, 25, 651, DateTimeKind.Local).AddTicks(7377));
        }
    }
}
