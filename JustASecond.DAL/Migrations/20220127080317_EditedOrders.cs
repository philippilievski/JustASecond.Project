using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JustASecond.DAL.Migrations
{
    public partial class EditedOrders : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TableId",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "rrrrrrrr-22b1-4479-j58g-rrrrrrrr",
                column: "ConcurrencyStamp",
                value: "13c7f69b-a665-4e07-8536-27650bebe551");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "rrrrrrrr-l0w6-hhhh-jf84-rrrrrrrr",
                column: "ConcurrencyStamp",
                value: "0b831b6c-e3d8-4133-a8af-c938d5f06c90");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "z65dbe81-22b1-4479-j58g-d730ap050aa1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bfed62c1-95af-4e3e-a6be-1e8df9affb2f", "AQAAAAEAACcQAAAAEEfHQtOpZ+CCK+dyQuu5CMOPU14Yk5//taVaUNwtZwT/AbL8t0TLSSJK2Vhk8KBNYA==", "4a8d8b89-d91b-40d9-bfe3-489c698dc2de" });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_TableId",
                table: "Orders",
                column: "TableId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Tables_TableId",
                table: "Orders",
                column: "TableId",
                principalTable: "Tables",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Tables_TableId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_TableId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "TableId",
                table: "Orders");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "rrrrrrrr-22b1-4479-j58g-rrrrrrrr",
                column: "ConcurrencyStamp",
                value: "954a3e8d-4501-4042-a899-13f729443ba5");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "rrrrrrrr-l0w6-hhhh-jf84-rrrrrrrr",
                column: "ConcurrencyStamp",
                value: "f429357d-352d-47a2-bd84-cc3b6ad9843e");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "z65dbe81-22b1-4479-j58g-d730ap050aa1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6d68c1cb-de4b-479c-82e1-10b0593514aa", "AQAAAAEAACcQAAAAEGpzZGS+VEj1qsnkbxojS1dGMJWBABReBnLLzZldvYkWH6mY9HXXbCMvYnxDVac8wQ==", "459acc30-8236-47ea-b841-fe99476ae605" });
        }
    }
}
