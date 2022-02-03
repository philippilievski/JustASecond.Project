using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JustASecond.DAL.Migrations
{
    public partial class completedDateTime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Completed",
                table: "Orders",
                type: "datetime(6)",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "tinyint(1)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "Completed",
                table: "Orders",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldNullable: true);
        }
    }
}
