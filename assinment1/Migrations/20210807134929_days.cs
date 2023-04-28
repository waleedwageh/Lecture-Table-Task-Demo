using Microsoft.EntityFrameworkCore.Migrations;

namespace assinment1.Migrations
{
    public partial class days : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Days",
                table: "Sections",
                newName: "LastDays");

            migrationBuilder.AddColumn<string>(
                name: "FirstDay",
                table: "Sections",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstDay",
                table: "Sections");

            migrationBuilder.RenameColumn(
                name: "LastDays",
                table: "Sections",
                newName: "Days");
        }
    }
}
