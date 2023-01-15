using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TesteClient.Migrations
{
    public partial class mig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe - afbf - 59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "424391c4-de5a-494a-8372-8cf4db3889d2", "AQAAAAEAACcQAAAAEPzpP1YyLomWeb8iEdH3RMDQ/KO5AhhvdbarXO4tiEnhOjdUhSVsAgv1AzeUohMdQw==", "cfc505c2-22b6-4112-9a07-1e06fe0bed54" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe - afbf - 59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4e2e6675-ba28-4cd4-aef6-7bd2755ca12c", "AQAAAAEAACcQAAAAELmLlG8F36eSIS0M/ZZjrxrVR9ZXljtax02q03OSaxTLPrkXc4DuGVSN10xueHuQ8w==", "dfda2bae-d67c-424c-9a8a-06917184aac1" });
        }
    }
}
