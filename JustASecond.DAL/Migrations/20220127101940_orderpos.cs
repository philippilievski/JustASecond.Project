using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JustASecond.DAL.Migrations
{
    public partial class orderpos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TableId",
                table: "Orders",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Amount",
                table: "OrderPositions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "rrrrrrrr-22b1-4479-j58g-rrrrrrrr",
                column: "ConcurrencyStamp",
                value: "d41f4e3c-f132-492f-bfea-871029987d60");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "rrrrrrrr-l0w6-hhhh-jf84-rrrrrrrr",
                column: "ConcurrencyStamp",
                value: "5d5b7af1-2f60-4292-a1fc-5b8910fdc881");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "z65dbe81-22b1-4479-j58g-d730ap050aa1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "df50a7f3-b7dd-46c3-bfbe-20c77a134b60", "AQAAAAEAACcQAAAAED8c29OQb5nLQOKF2SRD4xXG58u5CqUQTcDjTxbrNt/4W6FH3TCixoDe3EiCAma9yA==", "7e4ca425-f659-47cf-8c74-ce1940c0de5f" });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_TableId",
                table: "Orders",
                column: "TableId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Tables_TableId",
                table: "Orders",
                column: "TableId",
                principalTable: "Tables",
                principalColumn: "Id");
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

            migrationBuilder.DropColumn(
                name: "Amount",
                table: "OrderPositions");

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
