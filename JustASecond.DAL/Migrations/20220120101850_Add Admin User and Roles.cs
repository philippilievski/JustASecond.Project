using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JustASecond.DAL.Migrations
{
    public partial class AddAdminUserandRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WaiterCalls",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CalledAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    WaiterId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AcceptedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    TableId = table.Column<int>(type: "int", nullable: false),
                    TableId1 = table.Column<string>(type: "varchar(255)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WaiterCalls", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WaiterCalls_AspNetUsers_WaiterId",
                        column: x => x.WaiterId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WaiterCalls_Tables_TableId1",
                        column: x => x.TableId1,
                        principalTable: "Tables",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "rrrrrrrr-22b1-4479-j58g-rrrrrrrr", "5c8221e0-9423-4433-8565-f99f9a5a3834", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "rrrrrrrr-l0w6-hhhh-jf84-rrrrrrrr", "096816c5-f9f7-479a-a529-4a325f1cea41", "Waiter", "WAITER" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "z65dbe81-22b1-4479-j58g-d730ap050aa1", 0, "73692c47-fdb1-49fc-bb87-272fadb9d0a4", "admin@justasecond.com", true, false, null, "ADMIN@JUSTASECOND.COM", "ADMIN@JUSTASECOND.COM", "AQAAAAEAACcQAAAAEDjCSVcyCoAzFxhC1entK76aFQI55+lgAih4dfryA3q8HlKLeOSuG0smyh55KTXtrg==", null, false, "f62ce89d-d758-4979-b157-f51a55f8df3c", false, "admin@justasecond.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "rrrrrrrr-22b1-4479-j58g-rrrrrrrr", "z65dbe81-22b1-4479-j58g-d730ap050aa1" });

            migrationBuilder.CreateIndex(
                name: "IX_WaiterCalls_TableId1",
                table: "WaiterCalls",
                column: "TableId1");

            migrationBuilder.CreateIndex(
                name: "IX_WaiterCalls_WaiterId",
                table: "WaiterCalls",
                column: "WaiterId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WaiterCalls");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "rrrrrrrr-l0w6-hhhh-jf84-rrrrrrrr");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "rrrrrrrr-22b1-4479-j58g-rrrrrrrr", "z65dbe81-22b1-4479-j58g-d730ap050aa1" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "rrrrrrrr-22b1-4479-j58g-rrrrrrrr");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "z65dbe81-22b1-4479-j58g-d730ap050aa1");
        }
    }
}
