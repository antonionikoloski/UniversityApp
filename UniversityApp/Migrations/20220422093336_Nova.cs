using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniversityApp.Migrations
{
    public partial class Nova : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EnrollMent_Students_StudentIdId",
                table: "EnrollMent");

            migrationBuilder.DropForeignKey(
                name: "FK_EnrollMent_Subjects_SubjectIdId",
                table: "EnrollMent");

            migrationBuilder.DropForeignKey(
                name: "FK_Subjects_Teachers_TeachersId",
                table: "Subjects");

            migrationBuilder.DropIndex(
                name: "IX_Subjects_TeachersId",
                table: "Subjects");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EnrollMent",
                table: "EnrollMent");

            migrationBuilder.DropColumn(
                name: "TeachersId",
                table: "Subjects");

            migrationBuilder.RenameTable(
                name: "EnrollMent",
                newName: "Enrollment");

            migrationBuilder.RenameColumn(
                name: "SubjectIdId",
                table: "Enrollment",
                newName: "SubjectId");

            migrationBuilder.RenameColumn(
                name: "StudentIdId",
                table: "Enrollment",
                newName: "StudentId");

            migrationBuilder.RenameIndex(
                name: "IX_EnrollMent_SubjectIdId",
                table: "Enrollment",
                newName: "IX_Enrollment_SubjectId");

            migrationBuilder.RenameIndex(
                name: "IX_EnrollMent_StudentIdId",
                table: "Enrollment",
                newName: "IX_Enrollment_StudentId");

            migrationBuilder.AlterColumn<int>(
                name: "SecondTeacherId",
                table: "Subjects",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "FirstTeacherId",
                table: "Subjects",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Enrollment",
                table: "Enrollment",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Subjects_FirstTeacherId",
                table: "Subjects",
                column: "FirstTeacherId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Subjects_Teachers_FirstTeacherId",
                table: "Subjects",
                column: "FirstTeacherId",
                principalTable: "Teachers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Enrollment_Students_StudentId",
                table: "Enrollment");

            migrationBuilder.DropForeignKey(
                name: "FK_Enrollment_Subjects_SubjectId",
                table: "Enrollment");

            migrationBuilder.DropForeignKey(
                name: "FK_Subjects_Teachers_FirstTeacherId",
                table: "Subjects");

            migrationBuilder.DropIndex(
                name: "IX_Subjects_FirstTeacherId",
                table: "Subjects");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Enrollment",
                table: "Enrollment");

            migrationBuilder.RenameTable(
                name: "Enrollment",
                newName: "EnrollMent");

            migrationBuilder.RenameColumn(
                name: "SubjectId",
                table: "EnrollMent",
                newName: "SubjectIdId");

            migrationBuilder.RenameColumn(
                name: "StudentId",
                table: "EnrollMent",
                newName: "StudentIdId");

            migrationBuilder.RenameIndex(
                name: "IX_Enrollment_SubjectId",
                table: "EnrollMent",
                newName: "IX_EnrollMent_SubjectIdId");

            migrationBuilder.RenameIndex(
                name: "IX_Enrollment_StudentId",
                table: "EnrollMent",
                newName: "IX_EnrollMent_StudentIdId");

            migrationBuilder.AlterColumn<int>(
                name: "SecondTeacherId",
                table: "Subjects",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "FirstTeacherId",
                table: "Subjects",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TeachersId",
                table: "Subjects",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_EnrollMent",
                table: "EnrollMent",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Subjects_TeachersId",
                table: "Subjects",
                column: "TeachersId");

            migrationBuilder.AddForeignKey(
                name: "FK_EnrollMent_Students_StudentIdId",
                table: "EnrollMent",
                column: "StudentIdId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EnrollMent_Subjects_SubjectIdId",
                table: "EnrollMent",
                column: "SubjectIdId",
                principalTable: "Subjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Subjects_Teachers_TeachersId",
                table: "Subjects",
                column: "TeachersId",
                principalTable: "Teachers",
                principalColumn: "Id");
        }
    }
}
