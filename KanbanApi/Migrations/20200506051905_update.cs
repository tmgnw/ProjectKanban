using Microsoft.EntityFrameworkCore.Migrations;

namespace KanbanApi.Migrations
{
    public partial class update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalTasks",
                table: "TB_M_Project");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TotalTasks",
                table: "TB_M_Project",
                nullable: false,
                defaultValue: 0);
        }
    }
}
