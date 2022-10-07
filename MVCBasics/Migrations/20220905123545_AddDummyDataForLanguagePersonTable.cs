using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVCBasics.Migrations
{
    public partial class AddDummyDataForLanguagePersonTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "LanguagePerson",
                columns: new[] { "LanguagesID", "PeopleID" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 1, 3 },
                    { 1, 4 },
                    { 1, 5 },
                    { 1, 6 },
                    { 1, 9 },
                    { 1, 13 },
                    { 2, 1 },
                    { 2, 2 },
                    { 2, 3 },
                    { 2, 6 },
                    { 2, 7 },
                    { 2, 8 },
                    { 2, 9 },
                    { 2, 10 },
                    { 2, 11 },
                    { 2, 12 },
                    { 2, 13 },
                    { 2, 14 },
                    { 3, 9 },
                    { 3, 13 },
                    { 3, 14 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "LanguagePerson",
                keyColumns: new[] { "LanguagesID", "PeopleID" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "LanguagePerson",
                keyColumns: new[] { "LanguagesID", "PeopleID" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "LanguagePerson",
                keyColumns: new[] { "LanguagesID", "PeopleID" },
                keyValues: new object[] { 1, 3 });

            migrationBuilder.DeleteData(
                table: "LanguagePerson",
                keyColumns: new[] { "LanguagesID", "PeopleID" },
                keyValues: new object[] { 1, 4 });

            migrationBuilder.DeleteData(
                table: "LanguagePerson",
                keyColumns: new[] { "LanguagesID", "PeopleID" },
                keyValues: new object[] { 1, 5 });

            migrationBuilder.DeleteData(
                table: "LanguagePerson",
                keyColumns: new[] { "LanguagesID", "PeopleID" },
                keyValues: new object[] { 1, 6 });

            migrationBuilder.DeleteData(
                table: "LanguagePerson",
                keyColumns: new[] { "LanguagesID", "PeopleID" },
                keyValues: new object[] { 1, 9 });

            migrationBuilder.DeleteData(
                table: "LanguagePerson",
                keyColumns: new[] { "LanguagesID", "PeopleID" },
                keyValues: new object[] { 1, 13 });

            migrationBuilder.DeleteData(
                table: "LanguagePerson",
                keyColumns: new[] { "LanguagesID", "PeopleID" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "LanguagePerson",
                keyColumns: new[] { "LanguagesID", "PeopleID" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "LanguagePerson",
                keyColumns: new[] { "LanguagesID", "PeopleID" },
                keyValues: new object[] { 2, 3 });

            migrationBuilder.DeleteData(
                table: "LanguagePerson",
                keyColumns: new[] { "LanguagesID", "PeopleID" },
                keyValues: new object[] { 2, 6 });

            migrationBuilder.DeleteData(
                table: "LanguagePerson",
                keyColumns: new[] { "LanguagesID", "PeopleID" },
                keyValues: new object[] { 2, 7 });

            migrationBuilder.DeleteData(
                table: "LanguagePerson",
                keyColumns: new[] { "LanguagesID", "PeopleID" },
                keyValues: new object[] { 2, 8 });

            migrationBuilder.DeleteData(
                table: "LanguagePerson",
                keyColumns: new[] { "LanguagesID", "PeopleID" },
                keyValues: new object[] { 2, 9 });

            migrationBuilder.DeleteData(
                table: "LanguagePerson",
                keyColumns: new[] { "LanguagesID", "PeopleID" },
                keyValues: new object[] { 2, 10 });

            migrationBuilder.DeleteData(
                table: "LanguagePerson",
                keyColumns: new[] { "LanguagesID", "PeopleID" },
                keyValues: new object[] { 2, 11 });

            migrationBuilder.DeleteData(
                table: "LanguagePerson",
                keyColumns: new[] { "LanguagesID", "PeopleID" },
                keyValues: new object[] { 2, 12 });

            migrationBuilder.DeleteData(
                table: "LanguagePerson",
                keyColumns: new[] { "LanguagesID", "PeopleID" },
                keyValues: new object[] { 2, 13 });

            migrationBuilder.DeleteData(
                table: "LanguagePerson",
                keyColumns: new[] { "LanguagesID", "PeopleID" },
                keyValues: new object[] { 2, 14 });

            migrationBuilder.DeleteData(
                table: "LanguagePerson",
                keyColumns: new[] { "LanguagesID", "PeopleID" },
                keyValues: new object[] { 3, 9 });

            migrationBuilder.DeleteData(
                table: "LanguagePerson",
                keyColumns: new[] { "LanguagesID", "PeopleID" },
                keyValues: new object[] { 3, 13 });

            migrationBuilder.DeleteData(
                table: "LanguagePerson",
                keyColumns: new[] { "LanguagesID", "PeopleID" },
                keyValues: new object[] { 3, 14 });
        }
    }
}
