using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JustASecond.DAL.Migrations
{
    public partial class AddProductTypeandDescription : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Products",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "rrrrrrrr-22b1-4479-j58g-rrrrrrrr",
                column: "ConcurrencyStamp",
                value: "d424b4bc-24f0-48e3-af50-eb1c732b7ab8");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "rrrrrrrr-l0w6-hhhh-jf84-rrrrrrrr",
                column: "ConcurrencyStamp",
                value: "94c9c99d-bbdc-40c6-a164-9d6bafebca7e");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "z65dbe81-22b1-4479-j58g-d730ap050aa1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b76cb392-c658-4270-9f89-eb6d9bbe2cd6", "AQAAAAEAACcQAAAAEHbtyZlI6s/1vV+FURaUC1PjLN7iPqUmw+GGDCNLNJkmboGiH7kk09cuqwwmG9Jhvg==", "d04ddada-36fb-40b1-ac93-c3a8b4f04c5a" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Products");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "rrrrrrrr-22b1-4479-j58g-rrrrrrrr",
                column: "ConcurrencyStamp",
                value: "5c8221e0-9423-4433-8565-f99f9a5a3834");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "rrrrrrrr-l0w6-hhhh-jf84-rrrrrrrr",
                column: "ConcurrencyStamp",
                value: "096816c5-f9f7-479a-a529-4a325f1cea41");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "z65dbe81-22b1-4479-j58g-d730ap050aa1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "73692c47-fdb1-49fc-bb87-272fadb9d0a4", "AQAAAAEAACcQAAAAEDjCSVcyCoAzFxhC1entK76aFQI55+lgAih4dfryA3q8HlKLeOSuG0smyh55KTXtrg==", "f62ce89d-d758-4979-b157-f51a55f8df3c" });
        }
    }
}
