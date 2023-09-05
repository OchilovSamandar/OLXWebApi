using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OLXWebApi.Migrations
{
    public partial class s : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedAt",
                value: new DateTime(2023, 9, 5, 7, 44, 34, 238, DateTimeKind.Utc).AddTicks(4344));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedAt",
                value: new DateTime(2023, 9, 5, 7, 44, 34, 238, DateTimeKind.Utc).AddTicks(4346));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedAt",
                value: new DateTime(2023, 8, 31, 6, 8, 21, 813, DateTimeKind.Utc).AddTicks(7576));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedAt",
                value: new DateTime(2023, 8, 31, 6, 8, 21, 813, DateTimeKind.Utc).AddTicks(7578));
        }
    }
}
