using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PairMatcher.Migrations
{
    public partial class studentpaircolumnadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Groups");

            migrationBuilder.AddColumn<int>(
                name: "PairStudentId",
                table: "Students",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Students_PairStudentId",
                table: "Students",
                column: "PairStudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Students_PairStudentId",
                table: "Students",
                column: "PairStudentId",
                principalTable: "Students",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Students_PairStudentId",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_PairStudentId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "PairStudentId",
                table: "Students");

            migrationBuilder.CreateTable(
                name: "Groups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groups", x => x.Id);
                });
        }
    }
}
