using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FriendsLessons.Migrations
{
    public partial class add_frienship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Friendship",
                schema: "dbo",
                columns: table => new
                {
                    MyId = table.Column<int>(type: "int", nullable: false),
                    YourId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Friendship", x => new { x.MyId, x.YourId });
                    table.ForeignKey(
                        name: "FK_Friendship_User_MyId",
                        column: x => x.MyId,
                        principalSchema: "dbo",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Friendship_User_YourId",
                        column: x => x.YourId,
                        principalSchema: "dbo",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Friendship_YourId",
                schema: "dbo",
                table: "Friendship",
                column: "YourId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Friendship",
                schema: "dbo");
        }
    }
}
