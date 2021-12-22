using Microsoft.EntityFrameworkCore.Migrations;

namespace back_end.Migrations
{
    public partial class QuestUserManagement : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_QuestUserManagement_SubQuestID",
                table: "QuestUserManagement",
                column: "SubQuestID");

            migrationBuilder.AddForeignKey(
                name: "FK_QuestUserManagement_SubQuest_SubQuestID",
                table: "QuestUserManagement",
                column: "SubQuestID",
                principalTable: "SubQuest",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QuestUserManagement_SubQuest_SubQuestID",
                table: "QuestUserManagement");

            migrationBuilder.DropIndex(
                name: "IX_QuestUserManagement_SubQuestID",
                table: "QuestUserManagement");
        }
    }
}
