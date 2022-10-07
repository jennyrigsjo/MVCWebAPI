using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVCBasics.Migrations
{
    public partial class AddUserRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                values: new object[] { "5c190a13-d3f7-42e6-8057-0d9a87a50488", "94534fe6-8720-459b-8da6-0e8ae4607c75", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "86decdcc-c750-455e-bf62-639f81c6cbba", "0683dcb6-798c-4ad0-9b23-62b1b4cbe17b", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DateOfBirth", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "b3e15926-4202-407c-bd95-afc71507ea52", 0, "88f69c72-5bc6-492e-aba1-f001997216ec", "19820320", "jenny.rigsjo@live.com", true, "Jenny", "Rigsjö", false, null, "jenny.rigsjo@live.com", "jenny.rigsjo@live.com", "AQAAAAEAACcQAAAAEK+hTGEeSbO6LM+xGvXM0kyM2XN3HuyWVPZnGmKVRP/SB2RZ/cKAUd84ZPFSdEJD/g==", null, false, "bfb238c9-3a43-4990-9ffd-ac7ad0290a72", false, "jenny.rigsjo@live.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "86decdcc-c750-455e-bf62-639f81c6cbba", "b3e15926-4202-407c-bd95-afc71507ea52" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5c190a13-d3f7-42e6-8057-0d9a87a50488");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "86decdcc-c750-455e-bf62-639f81c6cbba", "b3e15926-4202-407c-bd95-afc71507ea52" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "86decdcc-c750-455e-bf62-639f81c6cbba");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b3e15926-4202-407c-bd95-afc71507ea52");

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
    }
}
