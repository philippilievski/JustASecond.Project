using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JustASecond.DAL.Migrations
{
    public partial class changePriceType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Products",
                type: "decimal(65,30)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "rrrrrrrr-22b1-4479-j58g-rrrrrrrr",
                column: "ConcurrencyStamp",
                value: "534cca46-46b4-44e7-89ce-c79f3ca098af");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "rrrrrrrr-l0w6-hhhh-jf84-rrrrrrrr",
                column: "ConcurrencyStamp",
                value: "843a8ac0-54b6-46df-89b6-2fa561433e36");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "z65dbe81-22b1-4479-j58g-d730ap050aa1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3c3fc498-a160-401b-ad82-659c6bbbe75c", "AQAAAAEAACcQAAAAEDj5VHN32v5z8Kzu1ch7UBfXEY826jkYiPzxXPXUtqMBg9FGsa9830yIrsyIMAjCxQ==", "af5ae65a-3f82-4a31-b60c-178c9fbb7464" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Price",
                table: "Products",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(65,30)")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "rrrrrrrr-22b1-4479-j58g-rrrrrrrr",
                column: "ConcurrencyStamp",
                value: "af298360-3e58-418e-87e5-d833fddbf92f");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "rrrrrrrr-l0w6-hhhh-jf84-rrrrrrrr",
                column: "ConcurrencyStamp",
                value: "cbbca5f2-6932-488e-9691-33d7774488fa");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "z65dbe81-22b1-4479-j58g-d730ap050aa1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "847e98c6-da20-40f6-ad75-cb0300f31130", "AQAAAAEAACcQAAAAEGe8UxftdCJUN5vWi4jm8GAJHbfm+t71OeU2Q6UHqdVwZHFBrvBTjUlLcTwMeI378w==", "defc4e8d-c149-4478-9795-73e7a41f632a" });
        }
    }
}
