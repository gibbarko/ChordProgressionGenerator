using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ChordProgressionGenerator.Migrations
{
    public partial class ChordMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Chords",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CHORD_ROOT = table.Column<string>(nullable: true),
                    CHORD_TYPE = table.Column<string>(nullable: true),
                    CHORD_STRUCTURE = table.Column<string>(nullable: true),
                    FINGER_POSITIONS = table.Column<string>(nullable: true),
                    NOTE_NAMES = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chords", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Chords");
        }
    }
}
