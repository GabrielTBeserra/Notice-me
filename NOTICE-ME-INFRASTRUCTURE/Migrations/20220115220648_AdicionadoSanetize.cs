using Microsoft.EntityFrameworkCore.Migrations;

namespace NOTICE_ME_INFRASTRUCTURE.Migrations
{
    public partial class AdicionadoSanetize : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "sanetized_title",
                table: "Notice",
                nullable: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "sanetized_title",
                table: "Notice");
        }
    }
}
