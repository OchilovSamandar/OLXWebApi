using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OLXWebApi.Migrations
{
    public partial class d : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedAt",
                value: new DateTime(2023, 8, 18, 12, 47, 52, 915, DateTimeKind.Utc).AddTicks(1045));

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedAt",
                value: new DateTime(2023, 8, 18, 12, 47, 52, 915, DateTimeKind.Utc).AddTicks(1048));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2023, 8, 18, 12, 47, 52, 518, DateTimeKind.Utc).AddTicks(7484), "$2a$11$FwddZHBX84V8SJHEYFfZwuGOJbBq6Y0r9fgqUqapqwQopaJC0ktUK" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2023, 8, 18, 12, 47, 52, 713, DateTimeKind.Utc).AddTicks(7167), "$2a$11$wiE5R7ux8nH.RSCufdTF/uUzu2QEhZ6YevODMTpDAoK.2Xvm/6bO2" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2023, 8, 18, 12, 47, 52, 913, DateTimeKind.Utc).AddTicks(7350), "$2a$11$Kely.XqO4AAcku7gU8vQuO6b.r/fd0cXqcljEnD4scwRvmJNTaNTa" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedAt",
                value: new DateTime(2023, 8, 18, 5, 7, 26, 177, DateTimeKind.Utc).AddTicks(7035));

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedAt",
                value: new DateTime(2023, 8, 18, 5, 7, 26, 177, DateTimeKind.Utc).AddTicks(7037));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2023, 8, 18, 5, 7, 25, 800, DateTimeKind.Utc).AddTicks(6723), "$2a$11$ykCjl63RoiwN/gDXy6Cak.OqhbrQxjYYOK65hvWqaPP8oE6x7A9RK" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2023, 8, 18, 5, 7, 25, 984, DateTimeKind.Utc).AddTicks(8837), "$2a$11$zDBGUz.AiYazB0jdMu9bdO0DL5mlYOh90FhmAo2ofQQmFECX7jkBC" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2023, 8, 18, 5, 7, 26, 176, DateTimeKind.Utc).AddTicks(7821), "$2a$11$KW6fvg5sZe.jf8BBOQnRaud6.LwyhwBjusQ86ykXWBftgrP1SSvxW" });
        }
    }
}
