using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PairMatcher.Migrations
{
    public partial class samegendermatchadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "SameGenderMatch",
                table: "Students",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SameGenderMatch",
                table: "Students");
        }
    }
}
