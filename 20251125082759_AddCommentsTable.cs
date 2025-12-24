using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ATNewsprimeApp.Migrations
{
    /// <inheritdoc />
    public partial class AddCommentsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AllComment_AllNewses_NewsId",
                table: "AllComment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AllComment",
                table: "AllComment");

            migrationBuilder.RenameTable(
                name: "AllComment",
                newName: "AllComments");

            migrationBuilder.RenameIndex(
                name: "IX_AllComment_NewsId",
                table: "AllComments",
                newName: "IX_AllComments_NewsId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AllComments",
                table: "AllComments",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "AllAdmins",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 25, 13, 57, 59, 70, DateTimeKind.Local).AddTicks(7990));

            migrationBuilder.AddForeignKey(
                name: "FK_AllComments_AllNewses_NewsId",
                table: "AllComments",
                column: "NewsId",
                principalTable: "AllNewses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AllComments_AllNewses_NewsId",
                table: "AllComments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AllComments",
                table: "AllComments");

            migrationBuilder.RenameTable(
                name: "AllComments",
                newName: "AllComment");

            migrationBuilder.RenameIndex(
                name: "IX_AllComments_NewsId",
                table: "AllComment",
                newName: "IX_AllComment_NewsId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AllComment",
                table: "AllComment",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "AllAdmins",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 25, 13, 54, 45, 890, DateTimeKind.Local).AddTicks(8862));

            migrationBuilder.AddForeignKey(
                name: "FK_AllComment_AllNewses_NewsId",
                table: "AllComment",
                column: "NewsId",
                principalTable: "AllNewses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
