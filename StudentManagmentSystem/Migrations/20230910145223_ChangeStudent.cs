using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentManagmentSystem.Migrations
{
    /// <inheritdoc />
    public partial class ChangeStudent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DactyloscopyId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "EducationId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "RegistrationId",
                table: "Students");

            migrationBuilder.AddColumn<int>(
                name: "StudentId",
                table: "Educations",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StudentId",
                table: "Dactyloscopies",
                type: "integer",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "Educations");

            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "Dactyloscopies");

            migrationBuilder.AddColumn<int>(
                name: "DactyloscopyId",
                table: "Students",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EducationId",
                table: "Students",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OrderId",
                table: "Students",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RegistrationId",
                table: "Students",
                type: "integer",
                nullable: true);
        }
    }
}
