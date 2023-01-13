using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TesteClient.Migrations
{
    public partial class seed_db_order_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "totalPrice",
                table: "Order",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe - afbf - 59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d6a373f7-e103-4167-9d55-d44005d2194b", "AQAAAAEAACcQAAAAEPlYJMZc1T+gqBJc4ca/Iugk+CnheAqxa9AR8mjZyfjDoW4kW0/BfXGrwgvQ/l2B8A==", "e8edfff7-e3e0-4ea7-a2f6-b0ef89a77ed5" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "totalPrice",
                table: "Order");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe - afbf - 59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3a8d2019-99c7-4dc2-8e5e-ec1c4f86d248", "AQAAAAEAACcQAAAAEBua5ASuMRIychOHq6NT79IvbircTWWr/mfrnpXTQkw1X417UU7/GBtexPQ0kGtkTA==", "a780d4d2-8554-4b0f-a8df-97a61827789a" });
        }
    }
}
