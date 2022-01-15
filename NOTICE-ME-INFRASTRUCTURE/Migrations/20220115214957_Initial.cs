using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NOTICE_ME_INFRASTRUCTURE.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    email = table.Column<string>(nullable: false),
                    name = table.Column<string>(nullable: false),
                    password = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Notice",
                columns: table => new
                {
                    notice_id = table.Column<string>(type: "varchar(36)", nullable: false),
                    title = table.Column<string>(nullable: false),
                    content = table.Column<string>(nullable: false),
                    user_owner_id = table.Column<int>(nullable: false),
                    pubblication_date = table.Column<DateTime>(type: "DATETIME", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notice", x => x.notice_id);
                    table.ForeignKey(
                        name: "FK_Notice_User_user_owner_id",
                        column: x => x.user_owner_id,
                        principalTable: "User",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Notice_title",
                table: "Notice",
                column: "title",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Notice_user_owner_id",
                table: "Notice",
                column: "user_owner_id");

            migrationBuilder.CreateIndex(
                name: "IX_User_email",
                table: "User",
                column: "email",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Notice");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
