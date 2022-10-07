using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVCBasics.Migrations
{
    public partial class AddUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b62c48c9-1d56-48e6-a60e-0ea9db7a08c3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "caec67e9-a49b-44b9-a737-55bcd70c7acc");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "aa2bc7ae-ebee-4c6d-b444-b5cb57a34fc6", "c1040058-dfa9-47f7-88d9-4bf3269e603d", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "bc14f834-2dc0-469e-b2d0-00b2856aa703", "10a00fe9-4ca0-4eb3-a4aa-cb8fc4051a12", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DateOfBirth", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "6f3575fd-893a-48c8-b9a2-d33eae6940e1", 0, "99625870-7757-4fcc-a9b3-6e11003a1678", "19820320", "jenny.rigsjo@live.com", true, "Jenny", "Rigsjö", false, null, "jenny.rigsjo@live.com", "jenny.rigsjo@live.com", "AQAAAAEAACcQAAAAEGvdzafOakG5ClFxmoqT9/VDugIoMQxB9qV5Ps2gsnx5YSTBcTm6xU2qJWl3nz214Q==", null, false, "ac96f43d-b7ae-46d7-9005-da6101c8f1af", false, "jenny.rigsjo@live.com" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "aa2bc7ae-ebee-4c6d-b444-b5cb57a34fc6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bc14f834-2dc0-469e-b2d0-00b2856aa703");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6f3575fd-893a-48c8-b9a2-d33eae6940e1");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b62c48c9-1d56-48e6-a60e-0ea9db7a08c3", "f4190c11-1a3a-493e-a75e-09e3c49f1ca2", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "caec67e9-a49b-44b9-a737-55bcd70c7acc", "c39f9872-cd44-45fd-8c87-1a2a69d66b73", "User", "USER" });
        }
    }
}
