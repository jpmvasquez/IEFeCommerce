using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TesteClient.Migrations
{
    public partial class clients_ratings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProductRating",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    comment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    publishedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    productId = table.Column<int>(type: "int", nullable: false),
                    rating = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductRating", x => x.id);
                    table.ForeignKey(
                        name: "FK_ProductRating_Product_productId",
                        column: x => x.productId,
                        principalTable: "Product",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe - afbf - 59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "db5ca169-7658-46fa-bc44-8f37ac5bcdbe", "AQAAAAEAACcQAAAAEHYsGF9dMl8YWRz8GpqV0vByRDybyqWXcRHYVokzg9lAAWwRFHTQoSfJOovu+FkmfA==", "311b37bf-ff6a-43f2-8bf8-10a6e94acaec" });

            migrationBuilder.CreateIndex(
                name: "IX_ProductRating_productId",
                table: "ProductRating",
                column: "productId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductRating");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe - afbf - 59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "424391c4-de5a-494a-8372-8cf4db3889d2", "AQAAAAEAACcQAAAAEPzpP1YyLomWeb8iEdH3RMDQ/KO5AhhvdbarXO4tiEnhOjdUhSVsAgv1AzeUohMdQw==", "cfc505c2-22b6-4112-9a07-1e06fe0bed54" });
        }
    }
}
