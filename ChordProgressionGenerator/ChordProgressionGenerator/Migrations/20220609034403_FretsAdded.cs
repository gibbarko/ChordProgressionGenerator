using Microsoft.EntityFrameworkCore.Migrations;

namespace ChordProgressionGenerator.Migrations
{
    public partial class FretsAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FRETS",
                table: "Chords",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FRETS",
                table: "Chords");
        }
    }
}
