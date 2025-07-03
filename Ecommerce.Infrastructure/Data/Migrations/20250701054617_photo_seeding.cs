using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Ecommerce.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class photo_seeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ImageName",
                table: "Photos",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Description", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 7, 1, 8, 46, 15, 986, DateTimeKind.Local).AddTicks(2223), "Electronic items", new DateTime(2025, 7, 1, 8, 46, 15, 987, DateTimeKind.Local).AddTicks(7165) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Description", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 7, 1, 8, 46, 15, 987, DateTimeKind.Local).AddTicks(7914), "Apparel and garments", new DateTime(2025, 7, 1, 8, 46, 15, 987, DateTimeKind.Local).AddTicks(7917) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "Description", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 7, 1, 8, 46, 15, 987, DateTimeKind.Local).AddTicks(7919), "Various genres of books", new DateTime(2025, 7, 1, 8, 46, 15, 987, DateTimeKind.Local).AddTicks(7920) });

            migrationBuilder.InsertData(
                table: "Photos",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "ImageName", "IsDeleted", "ProductId", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 7, 1, 8, 46, 15, 988, DateTimeKind.Local).AddTicks(8558), null, "Laptop", false, 1, new DateTime(2025, 7, 1, 8, 46, 15, 988, DateTimeKind.Local).AddTicks(8579) },
                    { 2, new DateTime(2025, 7, 1, 8, 46, 15, 988, DateTimeKind.Local).AddTicks(9702), null, "Mobile", false, 2, new DateTime(2025, 7, 1, 8, 46, 15, 988, DateTimeKind.Local).AddTicks(9704) },
                    { 3, new DateTime(2025, 7, 1, 8, 46, 15, 988, DateTimeKind.Local).AddTicks(9705), null, "Tablet", false, 3, new DateTime(2025, 7, 1, 8, 46, 15, 988, DateTimeKind.Local).AddTicks(9706) },
                    { 4, new DateTime(2025, 7, 1, 8, 46, 15, 988, DateTimeKind.Local).AddTicks(9707), null, "Headphone", false, 4, new DateTime(2025, 7, 1, 8, 46, 15, 988, DateTimeKind.Local).AddTicks(9708) },
                    { 5, new DateTime(2025, 7, 1, 8, 46, 15, 988, DateTimeKind.Local).AddTicks(9709), null, "Smartwatch", false, 5, new DateTime(2025, 7, 1, 8, 46, 15, 988, DateTimeKind.Local).AddTicks(9710) }
                });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 7, 1, 8, 46, 15, 989, DateTimeKind.Local).AddTicks(4758), new DateTime(2025, 7, 1, 8, 46, 15, 989, DateTimeKind.Local).AddTicks(4767) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 7, 1, 8, 46, 15, 989, DateTimeKind.Local).AddTicks(5403), new DateTime(2025, 7, 1, 8, 46, 15, 989, DateTimeKind.Local).AddTicks(5405) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 7, 1, 8, 46, 15, 989, DateTimeKind.Local).AddTicks(5407), new DateTime(2025, 7, 1, 8, 46, 15, 989, DateTimeKind.Local).AddTicks(5408) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 7, 1, 8, 46, 15, 989, DateTimeKind.Local).AddTicks(5409), new DateTime(2025, 7, 1, 8, 46, 15, 989, DateTimeKind.Local).AddTicks(5410) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 7, 1, 8, 46, 15, 989, DateTimeKind.Local).AddTicks(5412), new DateTime(2025, 7, 1, 8, 46, 15, 989, DateTimeKind.Local).AddTicks(5412) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.AlterColumn<string>(
                name: "ImageName",
                table: "Photos",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Description", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 12, 20, 4, 24, 657, DateTimeKind.Local).AddTicks(4776), "Devices and gadgets", new DateTime(2025, 6, 12, 20, 4, 24, 658, DateTimeKind.Local).AddTicks(8770) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Description", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 12, 20, 4, 24, 658, DateTimeKind.Local).AddTicks(9564), "Apparel and accessories", new DateTime(2025, 6, 12, 20, 4, 24, 658, DateTimeKind.Local).AddTicks(9568) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "Description", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 12, 20, 4, 24, 658, DateTimeKind.Local).AddTicks(9570), "Literature and educational materials", new DateTime(2025, 6, 12, 20, 4, 24, 658, DateTimeKind.Local).AddTicks(9571) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 12, 20, 4, 24, 659, DateTimeKind.Local).AddTicks(8626), new DateTime(2025, 6, 12, 20, 4, 24, 659, DateTimeKind.Local).AddTicks(8646) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 12, 20, 4, 24, 659, DateTimeKind.Local).AddTicks(9364), new DateTime(2025, 6, 12, 20, 4, 24, 659, DateTimeKind.Local).AddTicks(9366) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 12, 20, 4, 24, 659, DateTimeKind.Local).AddTicks(9368), new DateTime(2025, 6, 12, 20, 4, 24, 659, DateTimeKind.Local).AddTicks(9369) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 12, 20, 4, 24, 659, DateTimeKind.Local).AddTicks(9370), new DateTime(2025, 6, 12, 20, 4, 24, 659, DateTimeKind.Local).AddTicks(9371) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 12, 20, 4, 24, 659, DateTimeKind.Local).AddTicks(9372), new DateTime(2025, 6, 12, 20, 4, 24, 659, DateTimeKind.Local).AddTicks(9373) });
        }
    }
}
