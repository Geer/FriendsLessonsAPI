using Microsoft.EntityFrameworkCore.Migrations;

namespace FriendsLessons.Migrations
{
    public partial class update_model : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LessonId",
                schema: "dbo",
                table: "User",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_User_LessonId",
                schema: "dbo",
                table: "User",
                column: "LessonId");

            migrationBuilder.AddForeignKey(
                name: "FK_User_Lesson_LessonId",
                schema: "dbo",
                table: "User",
                column: "LessonId",
                principalSchema: "dbo",
                principalTable: "Lesson",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_Lesson_LessonId",
                schema: "dbo",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_LessonId",
                schema: "dbo",
                table: "User");

            migrationBuilder.DropColumn(
                name: "LessonId",
                schema: "dbo",
                table: "User");
        }
    }
}
