using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AspNetCoreWebApiTask1.Migrations
{
    /// <inheritdoc />
    public partial class SeedSpecialBook : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Book",
                columns: new[] { "Id", "BookstoreId", "Discriminator", "Name", "SpecialEditionDetails" },
                values: new object[,]
                {
                    { 8, 1, "SpecialBook", "Book8", "SpecialEdition 1" },
                    { 9, 2, "SpecialBook", "Book9", "SpecialEdition 2" },
                    { 10, 3, "SpecialBook", "Book10", "SpecialEdition 3" },
                    { 11, 3, "SpecialBook", "Book11", "SpecialEdition 4" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Book",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Book",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Book",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Book",
                keyColumn: "Id",
                keyValue: 11);
        }
    }
}
