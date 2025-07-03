using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ecommerce.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class updateproductphoto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Price",
                table: "Products",
                newName: "OldPrice");

            migrationBuilder.RenameColumn(
                name: "ImageName",
                table: "Photos",
                newName: "PhotoName");

            migrationBuilder.AddColumn<decimal>(
                name: "NewPrice",
                table: "Products",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 7, 4, 0, 33, 13, 261, DateTimeKind.Local).AddTicks(7753), new DateTime(2025, 7, 4, 0, 33, 13, 263, DateTimeKind.Local).AddTicks(7451) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 7, 4, 0, 33, 13, 263, DateTimeKind.Local).AddTicks(8245), new DateTime(2025, 7, 4, 0, 33, 13, 263, DateTimeKind.Local).AddTicks(8248) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 7, 4, 0, 33, 13, 263, DateTimeKind.Local).AddTicks(8250), new DateTime(2025, 7, 4, 0, 33, 13, 263, DateTimeKind.Local).AddTicks(8251) });

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 7, 4, 0, 33, 13, 264, DateTimeKind.Local).AddTicks(6164), new DateTime(2025, 7, 4, 0, 33, 13, 264, DateTimeKind.Local).AddTicks(6175) });

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 7, 4, 0, 33, 13, 264, DateTimeKind.Local).AddTicks(6570), new DateTime(2025, 7, 4, 0, 33, 13, 264, DateTimeKind.Local).AddTicks(6571) });

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 7, 4, 0, 33, 13, 264, DateTimeKind.Local).AddTicks(6573), new DateTime(2025, 7, 4, 0, 33, 13, 264, DateTimeKind.Local).AddTicks(6574) });

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 7, 4, 0, 33, 13, 264, DateTimeKind.Local).AddTicks(6575), new DateTime(2025, 7, 4, 0, 33, 13, 264, DateTimeKind.Local).AddTicks(6576) });

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 7, 4, 0, 33, 13, 264, DateTimeKind.Local).AddTicks(6577), new DateTime(2025, 7, 4, 0, 33, 13, 264, DateTimeKind.Local).AddTicks(6578) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "NewPrice", "OldPrice", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 7, 4, 0, 33, 13, 265, DateTimeKind.Local).AddTicks(1495), 20m, 30m, new DateTime(2025, 7, 4, 0, 33, 13, 265, DateTimeKind.Local).AddTicks(1505) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "NewPrice", "OldPrice", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 7, 4, 0, 33, 13, 265, DateTimeKind.Local).AddTicks(2304), 20m, 30m, new DateTime(2025, 7, 4, 0, 33, 13, 265, DateTimeKind.Local).AddTicks(2306) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "NewPrice", "OldPrice", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 7, 4, 0, 33, 13, 265, DateTimeKind.Local).AddTicks(2308), 20m, 30m, new DateTime(2025, 7, 4, 0, 33, 13, 265, DateTimeKind.Local).AddTicks(2309) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "NewPrice", "OldPrice", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 7, 4, 0, 33, 13, 265, DateTimeKind.Local).AddTicks(2311), 20m, 30m, new DateTime(2025, 7, 4, 0, 33, 13, 265, DateTimeKind.Local).AddTicks(2312) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "NewPrice", "OldPrice", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 7, 4, 0, 33, 13, 265, DateTimeKind.Local).AddTicks(2313), 20m, 30m, new DateTime(2025, 7, 4, 0, 33, 13, 265, DateTimeKind.Local).AddTicks(2314) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NewPrice",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "OldPrice",
                table: "Products",
                newName: "Price");

            migrationBuilder.RenameColumn(
                name: "PhotoName",
                table: "Photos",
                newName: "ImageName");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 7, 1, 8, 46, 15, 986, DateTimeKind.Local).AddTicks(2223), new DateTime(2025, 7, 1, 8, 46, 15, 987, DateTimeKind.Local).AddTicks(7165) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 7, 1, 8, 46, 15, 987, DateTimeKind.Local).AddTicks(7914), new DateTime(2025, 7, 1, 8, 46, 15, 987, DateTimeKind.Local).AddTicks(7917) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 7, 1, 8, 46, 15, 987, DateTimeKind.Local).AddTicks(7919), new DateTime(2025, 7, 1, 8, 46, 15, 987, DateTimeKind.Local).AddTicks(7920) });

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 7, 1, 8, 46, 15, 988, DateTimeKind.Local).AddTicks(8558), new DateTime(2025, 7, 1, 8, 46, 15, 988, DateTimeKind.Local).AddTicks(8579) });

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 7, 1, 8, 46, 15, 988, DateTimeKind.Local).AddTicks(9702), new DateTime(2025, 7, 1, 8, 46, 15, 988, DateTimeKind.Local).AddTicks(9704) });

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 7, 1, 8, 46, 15, 988, DateTimeKind.Local).AddTicks(9705), new DateTime(2025, 7, 1, 8, 46, 15, 988, DateTimeKind.Local).AddTicks(9706) });

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 7, 1, 8, 46, 15, 988, DateTimeKind.Local).AddTicks(9707), new DateTime(2025, 7, 1, 8, 46, 15, 988, DateTimeKind.Local).AddTicks(9708) });

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 7, 1, 8, 46, 15, 988, DateTimeKind.Local).AddTicks(9709), new DateTime(2025, 7, 1, 8, 46, 15, 988, DateTimeKind.Local).AddTicks(9710) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Price", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 7, 1, 8, 46, 15, 989, DateTimeKind.Local).AddTicks(4758), 999.99m, new DateTime(2025, 7, 1, 8, 46, 15, 989, DateTimeKind.Local).AddTicks(4767) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Price", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 7, 1, 8, 46, 15, 989, DateTimeKind.Local).AddTicks(5403), 699.99m, new DateTime(2025, 7, 1, 8, 46, 15, 989, DateTimeKind.Local).AddTicks(5405) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "Price", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 7, 1, 8, 46, 15, 989, DateTimeKind.Local).AddTicks(5407), 19.99m, new DateTime(2025, 7, 1, 8, 46, 15, 989, DateTimeKind.Local).AddTicks(5408) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "Price", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 7, 1, 8, 46, 15, 989, DateTimeKind.Local).AddTicks(5409), 49.99m, new DateTime(2025, 7, 1, 8, 46, 15, 989, DateTimeKind.Local).AddTicks(5410) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "Price", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 7, 1, 8, 46, 15, 989, DateTimeKind.Local).AddTicks(5412), 14.99m, new DateTime(2025, 7, 1, 8, 46, 15, 989, DateTimeKind.Local).AddTicks(5412) });
        }
    }
}
