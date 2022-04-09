using Microsoft.EntityFrameworkCore.Migrations;

namespace FriendsLessons.Migrations
{
    public partial class update_model2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lesson_User_UserId",
                schema: "dbo",
                table: "Lesson");

            migrationBuilder.DropForeignKey(
                name: "FK_User_Lesson_LessonId",
                schema: "dbo",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_LessonId",
                schema: "dbo",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_Lesson_UserId",
                schema: "dbo",
                table: "Lesson");

            migrationBuilder.DropColumn(
                name: "LessonId",
                schema: "dbo",
                table: "User");

            migrationBuilder.DropColumn(
                name: "UserId",
                schema: "dbo",
                table: "Lesson");

            migrationBuilder.CreateTable(
                name: "UserLesson",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    LessonId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLesson", x => new { x.UserId, x.LessonId });
                    table.ForeignKey(
                        name: "FK_UserLesson_Lesson_LessonId",
                        column: x => x.LessonId,
                        principalSchema: "dbo",
                        principalTable: "Lesson",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserLesson_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "dbo",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserLesson_LessonId",
                table: "UserLesson",
                column: "LessonId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserLesson");

            migrationBuilder.AddColumn<int>(
                name: "LessonId",
                schema: "dbo",
                table: "User",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                schema: "dbo",
                table: "Lesson",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_User_LessonId",
                schema: "dbo",
                table: "User",
                column: "LessonId");

            migrationBuilder.CreateIndex(
                name: "IX_Lesson_UserId",
                schema: "dbo",
                table: "Lesson",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Lesson_User_UserId",
                schema: "dbo",
                table: "Lesson",
                column: "UserId",
                principalSchema: "dbo",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

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
    }
}
