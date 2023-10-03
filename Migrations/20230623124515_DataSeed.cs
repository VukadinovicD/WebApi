using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AspNetCoreWebApiTask1.Migrations
{
    /// <inheritdoc />
    public partial class DataSeed : Migration
    {

        
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Bookstore",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Library1" },
                    { 2, "Library2" },
                    { 3, "Library3" }
                });

            migrationBuilder.InsertData(
                table: "Book",
                columns: new[] { "Id", "BookstoreId", "Name" },
                values: new object[,]
                {
                    { 1, 1, "Book1" },
                    { 2, 1, "Book2" },
                    { 3, 2, "Book3" },
                    { 4, 3, "Book4" },
                    { 5, 3, "Book5" },
                    { 6, 3, "Book6" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Book",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Book",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Book",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Book",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Book",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Book",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Bookstore",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Bookstore",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Bookstore",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
