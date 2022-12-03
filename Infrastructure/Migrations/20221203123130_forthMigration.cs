using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class forthMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PostedToUser",
                table: "Posts",
                newName: "PostedToUserId");

            migrationBuilder.RenameColumn(
                name: "PostedByUser",
                table: "Posts",
                newName: "PostedByUserId");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedTime",
                value: new DateTime(2022, 12, 3, 13, 31, 30, 893, DateTimeKind.Local).AddTicks(6934));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedTime",
                value: new DateTime(2022, 12, 3, 13, 31, 30, 893, DateTimeKind.Local).AddTicks(7018));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PostedToUserId",
                table: "Posts",
                newName: "PostedToUser");

            migrationBuilder.RenameColumn(
                name: "PostedByUserId",
                table: "Posts",
                newName: "PostedByUser");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedTime",
                value: new DateTime(2022, 12, 3, 11, 56, 15, 483, DateTimeKind.Local).AddTicks(4314));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedTime",
                value: new DateTime(2022, 12, 3, 11, 56, 15, 483, DateTimeKind.Local).AddTicks(4388));
        }
    }
}
