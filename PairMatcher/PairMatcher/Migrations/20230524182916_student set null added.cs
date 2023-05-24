using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PairMatcher.Migrations
{
    public partial class studentsetnulladded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Students_PairStudentId",
                table: "Students");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Students_PairStudentId",
                table: "Students",
                column: "PairStudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Students_PairStudentId",
                table: "Students");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Students_PairStudentId",
                table: "Students",
                column: "PairStudentId",
                principalTable: "Students",
                principalColumn: "Id");
        }
    }
}
