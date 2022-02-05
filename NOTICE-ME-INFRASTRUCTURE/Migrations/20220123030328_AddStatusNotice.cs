using Microsoft.EntityFrameworkCore.Migrations;

namespace NOTICE_ME_INFRASTRUCTURE.Migrations
{
    public partial class AddStatusNotice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "status",
                table: "Notice",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "status",
                table: "Notice");
        }
    }
}
