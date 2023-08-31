using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OLXWebApi.Migrations
{
    public partial class addRolePermissionEntityies : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedAt",
                value: new DateTime(2023, 8, 31, 6, 2, 19, 69, DateTimeKind.Utc).AddTicks(7538));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedAt",
                value: new DateTime(2023, 8, 31, 6, 2, 19, 69, DateTimeKind.Utc).AddTicks(7540));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedAt",
                value: new DateTime(2023, 8, 31, 5, 33, 37, 210, DateTimeKind.Utc).AddTicks(7841));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedAt",
                value: new DateTime(2023, 8, 31, 5, 33, 37, 210, DateTimeKind.Utc).AddTicks(7842));
        }
    }
}
