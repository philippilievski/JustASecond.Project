using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JustASecond.DAL.Migrations
{
    public partial class deeznuts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "rrrrrrrr-22b1-4479-j58g-rrrrrrrr",
                column: "ConcurrencyStamp",
                value: "6cf38022-939e-481a-9f0f-8a4d8f6314b7");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "rrrrrrrr-l0w6-hhhh-jf84-rrrrrrrr",
                column: "ConcurrencyStamp",
                value: "225a5be3-34b5-4d60-bfdf-264cc97df17d");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "z65dbe81-22b1-4479-j58g-d730ap050aa1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9b54c91c-ee1a-430c-976c-0525817da136", "AQAAAAEAACcQAAAAEAFy0I0r8ZbmhrUR9icYNLzb0NO94Hv1WZlDozwFGSf7/YA8LNoMny0XH/GHZYlbKA==", "4276a8cb-d5b0-4310-8c61-cfb62758bf09" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "rrrrrrrr-22b1-4479-j58g-rrrrrrrr",
                column: "ConcurrencyStamp",
                value: "f5e85ba9-fda7-4769-82df-91302d1f2270");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "rrrrrrrr-l0w6-hhhh-jf84-rrrrrrrr",
                column: "ConcurrencyStamp",
                value: "3d191124-af10-49a8-b8e6-d98a7c323e3d");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "z65dbe81-22b1-4479-j58g-d730ap050aa1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e0ca5199-11e2-4455-aaab-b92f35cd5ead", "AQAAAAEAACcQAAAAEKrBaAX6bqaPTMKWJWlyMHO6zCEzoTGBLGFj8RAI1SdYDTqjSmQs4n1LBiboSdTLoQ==", "c471b3ee-a001-4ee2-ac28-0ec5b2bf42d9" });
        }
    }
}
