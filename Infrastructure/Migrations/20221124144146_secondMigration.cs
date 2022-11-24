using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class secondMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DirectMessages_Conversations_ConversationId",
                table: "DirectMessages");

            migrationBuilder.DropForeignKey(
                name: "FK_DirectMessages_Users_UserId",
                table: "DirectMessages");

            migrationBuilder.DropIndex(
                name: "IX_DirectMessages_UserId",
                table: "DirectMessages");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "DirectMessages");

            migrationBuilder.AlterColumn<int>(
                name: "ConversationId",
                table: "DirectMessages",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Conversations",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Conversations_UserId",
                table: "Conversations",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Conversations_Users_UserId",
                table: "Conversations",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DirectMessages_Conversations_ConversationId",
                table: "DirectMessages",
                column: "ConversationId",
                principalTable: "Conversations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Conversations_Users_UserId",
                table: "Conversations");

            migrationBuilder.DropForeignKey(
                name: "FK_DirectMessages_Conversations_ConversationId",
                table: "DirectMessages");

            migrationBuilder.DropIndex(
                name: "IX_Conversations_UserId",
                table: "Conversations");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Conversations");

            migrationBuilder.AlterColumn<int>(
                name: "ConversationId",
                table: "DirectMessages",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "DirectMessages",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_DirectMessages_UserId",
                table: "DirectMessages",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_DirectMessages_Conversations_ConversationId",
                table: "DirectMessages",
                column: "ConversationId",
                principalTable: "Conversations",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DirectMessages_Users_UserId",
                table: "DirectMessages",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
