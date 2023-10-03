using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AspNetCoreWebApiTask1.Migrations
{
    /// <inheritdoc />
    public partial class AddTableSpecialBooks : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Book",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SpecialEditionDetails",
                table: "Book",
                type: "TEXT",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Book",
                columns: new[] { "Id", "BookstoreId", "Discriminator", "Name" },
                values: new object[,]
                {
                    { 1, 1, "Book", "Book1" },
                    { 2, 1, "Book", "Book2" },
                    { 3, 2, "Book", "Book3" },
                    { 4, 3, "Book", "Book4" },
                    { 5, 3, "Book", "Book5" },
                    { 6, 3, "Book", "Book6" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Book");

            migrationBuilder.DropColumn(
                name: "SpecialEditionDetails",
                table: "Book");
        }
    }
}
