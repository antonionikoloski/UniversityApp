using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniversityApp.Migrations
{
    public partial class Probaj : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Enrollment_Students_StudentId",
                table: "Enrollment");

            migrationBuilder.DropForeignKey(
                name: "FK_Enrollment_Subjects_SubjectId",
                table: "Enrollment");

            migrationBuilder.RenameColumn(
                name: "SubjectId",
                table: "Enrollment",
                newName: "Pom2Id");

            migrationBuilder.RenameColumn(
                name: "StudentId",
                table: "Enrollment",
                newName: "Pom1Id");

            migrationBuilder.RenameIndex(
                name: "IX_Enrollment_SubjectId",
                table: "Enrollment",
                newName: "IX_Enrollment_Pom2Id");

            migrationBuilder.RenameIndex(
                name: "IX_Enrollment_StudentId",
                table: "Enrollment",
                newName: "IX_Enrollment_Pom1Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Enrollment_Students_Pom1Id",
                table: "Enrollment",
                column: "Pom1Id",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Enrollment_Subjects_Pom2Id",
                table: "Enrollment",
                column: "Pom2Id",
                principalTable: "Subjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Enrollment_Students_Pom1Id",
                table: "Enrollment");

            migrationBuilder.DropForeignKey(
                name: "FK_Enrollment_Subjects_Pom2Id",
                table: "Enrollment");

            migrationBuilder.RenameColumn(
                name: "Pom2Id",
                table: "Enrollment",
                newName: "SubjectId");

            migrationBuilder.RenameColumn(
                name: "Pom1Id",
                table: "Enrollment",
                newName: "StudentId");

            migrationBuilder.RenameIndex(
                name: "IX_Enrollment_Pom2Id",
                table: "Enrollment",
                newName: "IX_Enrollment_SubjectId");

            migrationBuilder.RenameIndex(
                name: "IX_Enrollment_Pom1Id",
                table: "Enrollment",
                newName: "IX_Enrollment_StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Enrollment_Students_StudentId",
                table: "Enrollment",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Enrollment_Subjects_SubjectId",
                table: "Enrollment",
                column: "SubjectId",
                principalTable: "Subjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
