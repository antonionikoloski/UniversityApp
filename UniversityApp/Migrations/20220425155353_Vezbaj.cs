using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniversityApp.Migrations
{
    public partial class Vezbaj : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<int>(
                name: "SubjectsId",
                table: "Students",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Subjects_FirstTeacherId",
                table: "Subjects",
                column: "FirstTeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_SubjectsId",
                table: "Students",
                column: "SubjectsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Subjects_SubjectsId",
                table: "Students",
                column: "SubjectsId",
                principalTable: "Subjects",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Subjects_Teachers_FirstTeacherId",
                table: "Subjects",
                column: "FirstTeacherId",
                principalTable: "Teachers",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Subjects_SubjectsId",
                table: "Students");

            migrationBuilder.DropForeignKey(
                name: "FK_Subjects_Teachers_FirstTeacherId",
                table: "Subjects");

            migrationBuilder.DropIndex(
                name: "IX_Subjects_FirstTeacherId",
                table: "Subjects");

            migrationBuilder.DropIndex(
                name: "IX_Students_SubjectsId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "SubjectsId",
                table: "Students");

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
    }
}
