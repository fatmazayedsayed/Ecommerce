using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Ecommerce.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class inital : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Photos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Photos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Photos_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "Description", "IsDeleted", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 6, 12, 20, 4, 24, 657, DateTimeKind.Local).AddTicks(4776), null, "Devices and gadgets", false, "Electronics", new DateTime(2025, 6, 12, 20, 4, 24, 658, DateTimeKind.Local).AddTicks(8770) },
                    { 2, new DateTime(2025, 6, 12, 20, 4, 24, 658, DateTimeKind.Local).AddTicks(9564), null, "Apparel and accessories", false, "Clothing", new DateTime(2025, 6, 12, 20, 4, 24, 658, DateTimeKind.Local).AddTicks(9568) },
                    { 3, new DateTime(2025, 6, 12, 20, 4, 24, 658, DateTimeKind.Local).AddTicks(9570), null, "Literature and educational materials", false, "Books", new DateTime(2025, 6, 12, 20, 4, 24, 658, DateTimeKind.Local).AddTicks(9571) }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "CreatedAt", "DeletedAt", "Description", "IsDeleted", "Name", "Price", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2025, 6, 12, 20, 4, 24, 659, DateTimeKind.Local).AddTicks(8626), null, "High performance laptop", false, "Laptop", 999.99m, new DateTime(2025, 6, 12, 20, 4, 24, 659, DateTimeKind.Local).AddTicks(8646) },
                    { 2, 1, new DateTime(2025, 6, 12, 20, 4, 24, 659, DateTimeKind.Local).AddTicks(9364), null, "Latest model smartphone", false, "Smartphone", 699.99m, new DateTime(2025, 6, 12, 20, 4, 24, 659, DateTimeKind.Local).AddTicks(9366) },
                    { 3, 2, new DateTime(2025, 6, 12, 20, 4, 24, 659, DateTimeKind.Local).AddTicks(9368), null, "Comfortable cotton t-shirt", false, "T-Shirt", 19.99m, new DateTime(2025, 6, 12, 20, 4, 24, 659, DateTimeKind.Local).AddTicks(9369) },
                    { 4, 2, new DateTime(2025, 6, 12, 20, 4, 24, 659, DateTimeKind.Local).AddTicks(9370), null, "Stylish denim jeans", false, "Jeans", 49.99m, new DateTime(2025, 6, 12, 20, 4, 24, 659, DateTimeKind.Local).AddTicks(9371) },
                    { 5, 3, new DateTime(2025, 6, 12, 20, 4, 24, 659, DateTimeKind.Local).AddTicks(9372), null, "Engaging fiction novel", false, "Fiction Book", 14.99m, new DateTime(2025, 6, 12, 20, 4, 24, 659, DateTimeKind.Local).AddTicks(9373) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Photos_ProductId",
                table: "Photos",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Photos");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
