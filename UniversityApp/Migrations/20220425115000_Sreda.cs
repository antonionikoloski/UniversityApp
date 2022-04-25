using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniversityApp.Migrations
{
    public partial class Sreda : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Subjects_Teachers_FirstTeacherId",
                table: "Subjects");

            migrationBuilder.DropIndex(
                name: "IX_Subjects_FirstTeacherId",
                table: "Subjects");

            migrationBuilder.CreateIndex(
                name: "IX_Subjects_SecondTeacherId",
                table: "Subjects",
                column: "SecondTeacherId");

            migrationBuilder.AddForeignKey(
                name: "FK_Subjects_Teachers_SecondTeacherId",
                table: "Subjects",
                column: "SecondTeacherId",
                principalTable: "Teachers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Subjects_Teachers_SecondTeacherId",
                table: "Subjects");

            migrationBuilder.DropIndex(
                name: "IX_Subjects_SecondTeacherId",
                table: "Subjects");

            migrationBuilder.CreateIndex(
                name: "IX_Subjects_FirstTeacherId",
                table: "Subjects",
                column: "FirstTeacherId");

            migrationBuilder.AddForeignKey(
                name: "FK_Subjects_Teachers_FirstTeacherId",
                table: "Subjects",
                column: "FirstTeacherId",
                principalTable: "Teachers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
