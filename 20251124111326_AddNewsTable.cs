using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ATNewsprimeApp.Migrations
{
    /// <inheritdoc />
    public partial class AddNewsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AllAdmins",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 24, 16, 43, 26, 467, DateTimeKind.Local).AddTicks(2613));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AllAdmins",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 24, 13, 6, 45, 466, DateTimeKind.Local).AddTicks(6096));
        }
    }
}
