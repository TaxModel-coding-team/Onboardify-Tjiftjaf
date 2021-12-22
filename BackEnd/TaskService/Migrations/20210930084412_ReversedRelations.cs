using Microsoft.EntityFrameworkCore.Migrations;

namespace back_end.Migrations
{
    public partial class ReversedRelations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SubQuest_Quest_QuestID",
                table: "SubQuest");

            migrationBuilder.AlterColumn<int>(
                name: "QuestID",
                table: "SubQuest",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "SubQuestID",
                table: "Quest",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_SubQuest_Quest_QuestID",
                table: "SubQuest",
                column: "QuestID",
                principalTable: "Quest",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SubQuest_Quest_QuestID",
                table: "SubQuest");

            migrationBuilder.DropColumn(
                name: "SubQuestID",
                table: "Quest");

            migrationBuilder.AlterColumn<int>(
                name: "QuestID",
                table: "SubQuest",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_SubQuest_Quest_QuestID",
                table: "SubQuest",
                column: "QuestID",
                principalTable: "Quest",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
