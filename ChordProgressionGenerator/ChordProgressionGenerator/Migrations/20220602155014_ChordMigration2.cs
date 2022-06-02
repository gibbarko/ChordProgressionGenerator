using Microsoft.EntityFrameworkCore.Migrations;

namespace ChordProgressionGenerator.Migrations
{
    public partial class ChordMigration2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "NOTE_NAMES",
                table: "Chords",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "json",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FINGER_POSITIONS",
                table: "Chords",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "json",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "NOTE_NAMES",
                table: "Chords",
                type: "json",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FINGER_POSITIONS",
                table: "Chords",
                type: "json",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
