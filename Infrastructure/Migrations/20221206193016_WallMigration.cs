using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class WallMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Users_PostedById",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_PostedById",
                table: "Comments");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DropColumn(
                name: "PostedById",
                table: "Comments");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PostedById",
                table: "Comments",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedTime", "Email", "Name", "Password" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 12, 4, 15, 10, 29, 741, DateTimeKind.Local).AddTicks(5147), "john@email.com", "John", "password" },
                    { 2, new DateTime(2022, 12, 4, 15, 10, 29, 741, DateTimeKind.Local).AddTicks(5223), "bill@email.com", "Bill", "password" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_PostedById",
                table: "Comments",
                column: "PostedById");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Users_PostedById",
                table: "Comments",
                column: "PostedById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
