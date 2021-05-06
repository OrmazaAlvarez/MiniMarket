using Microsoft.EntityFrameworkCore.Migrations;

namespace MiniMarketBackEnd.Migrations
{
    public partial class CreateDataBase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<short>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Description = table.Column<string>(maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Suppliers",
                columns: table => new
                {
                    SupplierId = table.Column<short>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Address = table.Column<string>(maxLength: 500, nullable: false),
                    PhoneNumber = table.Column<string>(maxLength: 20, nullable: false),
                    MailAddress = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suppliers", x => x.SupplierId);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(maxLength: 500, nullable: false),
                    CategoryId = table.Column<short>(nullable: false),
                    SupplierId = table.Column<short>(nullable: false),
                    Brand = table.Column<string>(maxLength: 50, nullable: false),
                    Model = table.Column<string>(maxLength: 50, nullable: false),
                    Measure = table.Column<string>(maxLength: 100, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(10, 2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_Suppliers_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Suppliers",
                        principalColumn: "SupplierId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Stocks",
                columns: table => new
                {
                    StockId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(nullable: false),
                    Count = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stocks", x => x.StockId);
                    table.ForeignKey(
                        name: "FK_Stocks_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "Description", "Name" },
                values: new object[,]
                {
                    { (short)1, "Category SEDAN 1", "SEDAN" },
                    { (short)2, "Category SUV 2", "SUV" },
                    { (short)3, "Category ALL TERRAIN 3", "ALL TERRAIN" }
                });

            migrationBuilder.InsertData(
                table: "Suppliers",
                columns: new[] { "SupplierId", "Address", "MailAddress", "Name", "PhoneNumber" },
                values: new object[] { (short)1, "El Empalme - Guayas - Ecuador", "lenin.ormaza@gmail.com", "Lenin Ormaza", "+593987461352" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "Brand", "CategoryId", "Description", "Measure", "Model", "Price", "SupplierId" },
                values: new object[,]
                {
                    { 1, "RENAULT", (short)1, "Description for KOLEOS", "L: 4.399mm, W: 1.652, H: 1.390", "KOLEOS", 10916m, (short)1 },
                    { 2, "RENAULT", (short)1, "Description for KOLEOS", "L: 4.399mm, W: 1.652, H: 1.390", "KOLEOS", 11219m, (short)1 },
                    { 3, "RENAULT", (short)1, "Description for KOLEOS", "L: 4.399mm, W: 1.652, H: 1.390", "KOLEOS", 10505m, (short)1 },
                    { 4, "RENAULT", (short)1, "Description for KOLEOS", "L: 4.399mm, W: 1.652, H: 1.390", "KOLEOS", 14520m, (short)1 },
                    { 5, "Ford", (short)2, "Description for FX-150", "L: 4.518mm, W: 1.799, H: 1.480", "FX-150", 11039m, (short)1 },
                    { 6, "Ford", (short)2, "Description for FX-150", "L: 4.518mm, W: 1.799, H: 1.480", "FX-150", 10769m, (short)1 },
                    { 7, "Ford", (short)2, "Description for FX-150", "L: 4.518mm, W: 1.799, H: 1.480", "FX-150", 10813m, (short)1 },
                    { 8, "Ford", (short)2, "Description for FX-150", "L: 4.518mm, W: 1.799, H: 1.480", "FX-150", 11807m, (short)1 },
                    { 9, "RENAULT", (short)1, "Description for KOLEOS", "L: 4.399mm, W: 1.652, H: 1.390", "KOLEOS", 14274m, (short)1 }
                });

            migrationBuilder.InsertData(
                table: "Stocks",
                columns: new[] { "StockId", "Count", "ProductId" },
                values: new object[,]
                {
                    { 1, 45, 1 },
                    { 2, 42, 2 },
                    { 3, 42, 3 },
                    { 4, 37, 4 },
                    { 5, 22, 5 },
                    { 6, 49, 6 },
                    { 7, 40, 7 },
                    { 8, 24, 8 },
                    { 9, 21, 9 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Categories_CategoryId",
                table: "Categories",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductId",
                table: "Products",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_SupplierId",
                table: "Products",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_Stocks_ProductId",
                table: "Stocks",
                column: "ProductId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Stocks_StockId",
                table: "Stocks",
                column: "StockId");

            migrationBuilder.CreateIndex(
                name: "IX_Suppliers_SupplierId",
                table: "Suppliers",
                column: "SupplierId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Stocks");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Suppliers");
        }
    }
}
