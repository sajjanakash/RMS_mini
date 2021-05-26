using Microsoft.EntityFrameworkCore.Migrations;

namespace RMS_API.Migrations
{
    public partial class SkillSetRemove : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SkillSet",
                table: "Employees");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SkillSet",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
