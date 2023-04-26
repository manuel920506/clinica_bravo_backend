using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace clinica_bravo_backend.Migrations
{
    /// <inheritdoc />
    public partial class ChangingNameUrl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "URL",
                table: "Topics");

            migrationBuilder.DropColumn(
                name: "URL",
                table: "SubTopics");

            migrationBuilder.AddColumn<string>(
                name: "Photo",
                table: "Topics",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Photo",
                table: "SubTopics",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Photo",
                table: "Topics");

            migrationBuilder.DropColumn(
                name: "Photo",
                table: "SubTopics");

            migrationBuilder.AddColumn<string>(
                name: "URL",
                table: "Topics",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "URL",
                table: "SubTopics",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
