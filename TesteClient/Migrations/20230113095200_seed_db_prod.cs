using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TesteClient.Migrations
{
    public partial class seed_db_prod : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe - afbf - 59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ddfeb46f-0e22-43b8-be3b-4bc53bbe7eb1", "AQAAAAEAACcQAAAAEEZt4hCK+CqflRs45KVVO2Hd7ivC28LndIBTj+xHGauR5708dOPDGAEv7FH7lqUXag==", "ece4214d-254f-4757-a304-d148dadb8177" });

            migrationBuilder.InsertData(
                table: "Brand",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { 1, "Sony" },
                    { 2, "Kodak" },
                    { 3, "Panasonic" },
                    { 4, "Nikon" },
                    { 5, "Olympus" },
                    { 6, "Fujifilm" },
                    { 7, "Canon" }
                });

            migrationBuilder.InsertData(
                table: "Image",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { 1, "DC-FZ82 EF-K.webp" },
                    { 2, "DC-FZ82 EF-K.webp" }
                });

            migrationBuilder.InsertData(
                table: "ProductDetails",
                columns: new[] { "id", "isoMax", "resolution", "stabilisator", "video", "zoomOptic" },
                values: new object[,]
                {
                    { 1, "1", "D80", true, "1", "1" },
                    { 2, "1", "D80", false, "1", "1" }
                });

            migrationBuilder.InsertData(
                table: "ProductType",
                columns: new[] { "id", "description", "name" },
                values: new object[,]
                {
                    { 1, null, "Reflex" },
                    { 2, null, "Hybride" },
                    { 3, null, "Bridge" },
                    { 4, null, "Compact" }
                });

            migrationBuilder.InsertData(
                table: "Techno",
                columns: new[] { "id", "description", "name" },
                values: new object[,]
                {
                    { 1, null, "Numérique" },
                    { 2, null, "Argentique" },
                    { 3, null, "Instantanée" },
                    { 4, null, "Jetable" }
                });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "id", "imageId", "name", "price", "productBrandId", "productDetailsId", "productTechnoId", "productTypeId" },
                values: new object[] { 1, 1, "D80", "1200,99", 1, 1, 1, 2 });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "id", "imageId", "name", "price", "productBrandId", "productDetailsId", "productTechnoId", "productTypeId" },
                values: new object[] { 2, 2, "Canon D80", "1400,00", 2, 2, 3, 3 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Brand",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Brand",
                keyColumn: "id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Brand",
                keyColumn: "id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Brand",
                keyColumn: "id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Brand",
                keyColumn: "id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ProductType",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ProductType",
                keyColumn: "id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Techno",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Techno",
                keyColumn: "id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Brand",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Brand",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ProductDetails",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ProductDetails",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ProductType",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ProductType",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Techno",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Techno",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe - afbf - 59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bc3f3ecf-7c62-44b1-8dce-5db3fd223d08", "AQAAAAEAACcQAAAAEPeEL6I7dHKgs/fXUs5WS1SAoN/EG9rB26UGhE2CloBq98YGq+KCC//A/sNl6/Wm7Q==", "4f58a1f5-9b34-4fbe-a60b-653fa809577c" });
        }
    }
}
