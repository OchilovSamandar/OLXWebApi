using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OLXWebApi.Migrations
{
    public partial class s : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte>(
                name: "Awatar",
                table: "Users",
                type: "tinyint",
                nullable: true,
                oldClrType: typeof(byte),
                oldType: "tinyint");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Awatar", "CreatedAt", "Email", "Firstname", "IsActive", "Lastname", "Password", "UpdatedAt", "UserRole" },
                values: new object[] { 1L, null, new DateTime(2023, 8, 16, 7, 33, 57, 152, DateTimeKind.Utc).AddTicks(576), "dotnetgo@icloud.com", "Mukhammadkarim", true, "Tukhtaboyev", "$2a$11$f0qrXfOdStj0cTVrJ.e7XuDEDz25O1gwLMvisu59Y48pSx8WM4SdS", null, 0 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Awatar", "CreatedAt", "Email", "Firstname", "IsActive", "Lastname", "Password", "UpdatedAt", "UserRole" },
                values: new object[] { 2L, null, new DateTime(2023, 8, 16, 7, 33, 57, 351, DateTimeKind.Utc).AddTicks(6522), "wonderboy1w3@gmail.com", "Jamshid", true, "Ma'ruf", "$2a$11$5YF31o0NP8j60ciGprxAiesacJDnfQlyGAO0yQcY6T1rSAnfj8HZu", null, 0 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.AlterColumn<byte>(
                name: "Awatar",
                table: "Users",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0,
                oldClrType: typeof(byte),
                oldType: "tinyint",
                oldNullable: true);
        }
    }
}
