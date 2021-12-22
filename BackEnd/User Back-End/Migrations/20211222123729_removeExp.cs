using Microsoft.EntityFrameworkCore.Migrations;

namespace User_Back_End.Migrations
{
    public partial class removeExp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExperiencePoints",
                table: "User");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ExperiencePoints",
                table: "User",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
