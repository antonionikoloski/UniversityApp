using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniversityApp.Migrations
{
    public partial class Najnovo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "id_foreignId",
                table: "Students",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "nadvoresen",
                table: "Students",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Students_id_foreignId",
                table: "Students",
                column: "id_foreignId");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_AspNetUsers_id_foreignId",
                table: "Students",
                column: "id_foreignId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_AspNetUsers_id_foreignId",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_id_foreignId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "id_foreignId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "nadvoresen",
                table: "Students");
        }
    }
}
