using Microsoft.EntityFrameworkCore.Migrations;

namespace back_end.Migrations
{
    public partial class RemovedSubQuestInQuest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SubQuestID",
                table: "Quest");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SubQuestID",
                table: "Quest",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
