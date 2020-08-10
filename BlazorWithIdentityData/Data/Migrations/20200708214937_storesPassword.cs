using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BlazorWithIdentityData.Data.Migrations
{
    public partial class storesPassword : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PasswordHistory",
                columns: table => new
                {
                    passwordHistoryId = table.Column<string>(nullable: false),
                    userId = table.Column<string>(nullable: true),
                    passwordHash = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PasswordHistory", x => x.passwordHistoryId);
                    table.ForeignKey(
                        name: "FK_PasswordHistory_AspNetUsers_userId",
                        column: x => x.userId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PasswordHistory_userId",
                table: "PasswordHistory",
                column: "userId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PasswordHistory");
        }
    }
}
