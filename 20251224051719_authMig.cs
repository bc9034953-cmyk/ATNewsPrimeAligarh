using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ATNewsprimeApp.Migrations
{
    /// <inheritdoc />
    public partial class authMig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AllAdmins",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 24, 10, 47, 19, 638, DateTimeKind.Local).AddTicks(5018));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AllAdmins",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 24, 10, 25, 1, 531, DateTimeKind.Local).AddTicks(295));
        }
    }
}
