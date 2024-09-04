using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Store.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InitDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "People",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<byte>(type: "tinyint", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedById = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_People", x => x.Id);
                    table.ForeignKey(
                        name: "FK_People_People_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "People",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Brands",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedById = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Brands_People_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "People",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Categorys",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedById = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorys", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Categorys_People_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "People",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Discount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Total = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedById = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_People_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "People",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BrandId = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    Stock = table.Column<long>(type: "bigint", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedById = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Brands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Products_Categorys_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categorys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_People_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "People",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Attachments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Content = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    Format = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: true),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedById = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attachments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Attachments_People_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "People",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Attachments_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "OrderDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Discount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedById = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderDetails_People_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "People",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OrderDetails_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Brands",
                columns: new[] { "Id", "CreateTime", "CreatedById", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 9, 4, 18, 37, 41, 770, DateTimeKind.Local).AddTicks(4811), null, "Samsung" },
                    { 2, new DateTime(2024, 9, 4, 18, 37, 41, 770, DateTimeKind.Local).AddTicks(4826), null, "Lg" },
                    { 3, new DateTime(2024, 9, 4, 18, 37, 41, 770, DateTimeKind.Local).AddTicks(4828), null, "IPhone" },
                    { 4, new DateTime(2024, 9, 4, 18, 37, 41, 770, DateTimeKind.Local).AddTicks(4830), null, "Lenovo" },
                    { 5, new DateTime(2024, 9, 4, 18, 37, 41, 770, DateTimeKind.Local).AddTicks(4832), null, "HP" }
                });

            migrationBuilder.InsertData(
                table: "Categorys",
                columns: new[] { "Id", "CreateTime", "CreatedById", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 9, 4, 18, 37, 41, 770, DateTimeKind.Local).AddTicks(6789), null, "Cell Phone" },
                    { 2, new DateTime(2024, 9, 4, 18, 37, 41, 770, DateTimeKind.Local).AddTicks(6795), null, "laptop" }
                });

            migrationBuilder.InsertData(
                table: "People",
                columns: new[] { "Id", "CreateTime", "CreatedById", "FirstName", "Gender", "LastName" },
                values: new object[] { 1, new DateTime(2024, 9, 4, 18, 37, 41, 771, DateTimeKind.Local).AddTicks(3146), null, "Javad", (byte)1, "Sagheb" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "BrandId", "CategoryId", "CreateTime", "CreatedById", "Description", "Stock", "Title" },
                values: new object[,]
                {
                    { 1, 5, 2, new DateTime(2024, 9, 4, 18, 37, 41, 771, DateTimeKind.Local).AddTicks(6975), null, "Processor: Intel Core i5-1235U, 10 x 1.30 GHz with Turbo Boost up to 10 x 4.40 GHz\r\nDisplay: 39 cm (15.6 inches), anti-glare, 1920 x 1080 pixels Full HD IPS\r\nMemory: 16GB DDR4 RAM Hard Drive: 1000GB SSD\r\nOperating system: Windows 11\r\nFeatures: Full HD display, Intel UHD graphics, HDMI, card reader, no drive, USB Type-C", 0L, "HP i5" },
                    { 2, 1, 1, new DateTime(2024, 9, 4, 18, 37, 41, 771, DateTimeKind.Local).AddTicks(6982), null, "For worry-free use: free warranty extension to 3 years - valid for customers who are resident in Germany\r\nEverything from your smartphone, all with AI: With the Galaxy S24 Ultra, you can easily edit photos, interpret calls in real time, and turn your notes into a clear summary¹ ² ³ ⁴.\r\nHigh resistance thanks to titanium: robustness, scratch resistance, water and dust protection thanks to Corning Gorilla Armor, the Galaxy S24 Ultra is ready for adventure, write, type and navigate with the integrated S Pen on the flat display\r\n200MP details that compete with reality: High resolution and AI processing, detects objects and reduces noise, zoom in the action, even at night - thanks to 1.6 times larger pixels and tele-OIS with larger angle6 8 / 9\r\nMobile gameplay: Fast computing power and almost twice the cooling system of the S23 Ultra – for a smooth graphics experience, high capacity battery and high energy efficiency for long gaming sessions6 ¹⁰ ¹¹ ¹ ¹²\r\nA bright adaptive Dynamic AMOLED display: 2,600 nits peak brightness, Redesigned Vision Booster improves contrast and colour representation for an impressive experience, reduced reflections and improved optical clarity thanks to Corning Gorilla Armor", 0L, "s24" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Attachments_CreatedById",
                table: "Attachments",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Attachments_ProductId",
                table: "Attachments",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Brands_CreatedById",
                table: "Brands",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Categorys_CreatedById",
                table: "Categorys",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_CreatedById",
                table: "OrderDetails",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_ProductId",
                table: "OrderDetails",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CreatedById",
                table: "Orders",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_People_CreatedById",
                table: "People",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Products_BrandId",
                table: "Products",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CreatedById",
                table: "Products",
                column: "CreatedById");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Attachments");

            migrationBuilder.DropTable(
                name: "OrderDetails");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Brands");

            migrationBuilder.DropTable(
                name: "Categorys");

            migrationBuilder.DropTable(
                name: "People");
        }
    }
}
