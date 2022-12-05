using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CommentMigration : Migration
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

            migrationBuilder.RenameColumn(
                name: "PostedById",
                table: "Comments",
                newName: "CommentedByUserId");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedTime",
                value: new DateTime(2022, 12, 3, 15, 41, 23, 321, DateTimeKind.Local).AddTicks(8200));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedTime",
                value: new DateTime(2022, 12, 3, 15, 41, 23, 321, DateTimeKind.Local).AddTicks(8286));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CommentedByUserId",
                table: "Comments",
                newName: "PostedById");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedTime",
                value: new DateTime(2022, 11, 30, 14, 0, 14, 97, DateTimeKind.Local).AddTicks(4571));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedTime",
                value: new DateTime(2022, 11, 30, 14, 0, 14, 97, DateTimeKind.Local).AddTicks(4630));

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
