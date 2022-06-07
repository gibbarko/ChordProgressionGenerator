using Microsoft.EntityFrameworkCore.Migrations;

namespace ChordProgressionGenerator.Migrations
{
    public partial class ProgressionUserUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "Progressions",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Progressions");
        }
    }
}
