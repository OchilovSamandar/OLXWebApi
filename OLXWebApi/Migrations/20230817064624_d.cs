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
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2023, 8, 17, 6, 46, 23, 991, DateTimeKind.Utc).AddTicks(3321), "$2a$11$QrNdVF.7Ov/EbBvo.t3m2O4h0lKmC.gYWuvoRJsK/oUHlM2iQHtnm" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2023, 8, 17, 6, 46, 24, 171, DateTimeKind.Utc).AddTicks(8742), "$2a$11$Ak/4epcincxG34NFAG5PRuiAKeTP1loxJFj7fGBBDGfJZqR6mk8ni" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Awatar", "CreatedAt", "Email", "Firstname", "IsActive", "Lastname", "Password", "UpdatedAt", "UserRole" },
                values: new object[] { 3L, null, new DateTime(2023, 8, 17, 6, 46, 24, 365, DateTimeKind.Utc).AddTicks(9134), "ochilovsamandar71@gmail.com", "Samandar", true, "Ochilov", "$2a$11$geCBlD7maEej6cMqxFa.ROb/EJn/fZL.5fcZcASd1U0gK9UrPRTZO", null, 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2023, 8, 16, 7, 33, 57, 152, DateTimeKind.Utc).AddTicks(576), "$2a$11$f0qrXfOdStj0cTVrJ.e7XuDEDz25O1gwLMvisu59Y48pSx8WM4SdS" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2023, 8, 16, 7, 33, 57, 351, DateTimeKind.Utc).AddTicks(6522), "$2a$11$5YF31o0NP8j60ciGprxAiesacJDnfQlyGAO0yQcY6T1rSAnfj8HZu" });
        }
    }
}
