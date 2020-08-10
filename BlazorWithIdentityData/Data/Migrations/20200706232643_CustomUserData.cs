using Microsoft.EntityFrameworkCore.Migrations;

namespace BlazorWithIdentityData.Data.Migrations
{
    public partial class CustomUserData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "251f777a-da77-46d0-ba7f-674202706cdf");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b29e82b6-dd2f-4d32-85dc-58c4bdb81f99");

            migrationBuilder.AddColumn<bool>(
                name: "IsAdmin",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsAdmin",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b29e82b6-dd2f-4d32-85dc-58c4bdb81f99", "a8422ca4-edb4-422f-9446-9a21b8e82786", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "251f777a-da77-46d0-ba7f-674202706cdf", "dcf12cad-260c-47cd-aaa7-53a0a4c1c19c", "Admin", "ADMIN" });
        }
    }
}
