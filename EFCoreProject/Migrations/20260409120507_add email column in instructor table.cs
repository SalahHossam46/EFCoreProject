using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCoreProject.Migrations
{
    /// <inheritdoc />
    public partial class addemailcolumnininstructortable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Instructors",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Instructors");
        }
    }
}
