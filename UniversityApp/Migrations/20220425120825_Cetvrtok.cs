using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniversityApp.Migrations
{
    public partial class Cetvrtok : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TeachersId",
                table: "Subjects",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Subjects_TeachersId",
                table: "Subjects",
                column: "TeachersId");

            migrationBuilder.AddForeignKey(
                name: "FK_Subjects_Teachers_TeachersId",
                table: "Subjects",
                column: "TeachersId",
                principalTable: "Teachers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Subjects_Teachers_TeachersId",
                table: "Subjects");

            migrationBuilder.DropIndex(
                name: "IX_Subjects_TeachersId",
                table: "Subjects");

            migrationBuilder.DropColumn(
                name: "TeachersId",
                table: "Subjects");
        }
    }
}
