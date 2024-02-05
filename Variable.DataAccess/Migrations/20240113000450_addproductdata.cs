using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Variable.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class addproductdata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ProductName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Storage = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Brand = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Color = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description1 = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description2 = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description3 = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Price = table.Column<double>(type: "double", nullable: false),
                    DisccountPrice = table.Column<double>(type: "double", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "DisplayOrder", "Name" },
                values: new object[,]
                {
                    { 1, 1, "Phones" },
                    { 2, 2, "Laptops" },
                    { 3, 3, "Pc components" },
                    { 4, 4, "Phone Accessories" },
                    { 5, 5, "Pc & Laptop Accessories" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Brand", "Color", "Description1", "Description2", "Description3", "DisccountPrice", "Price", "ProductName", "Storage" },
                values: new object[,]
                {
                    { 1, "Apple", "Natural Titanium", "iPhone 15 Pro has a strong and light aerospace-grade titanium design with a textured matte-glass back. It also features a Ceramic Shield front that’s tougher than any smartphone glass.", "The 6.1” Super Retina XDR display with ProMotion ramps up refresh rates to 120Hz when you need exceptional graphics performance. ", "A Pro-class GPU makes mobile games feel so immersive, with rich environments and realistic characters. ", 130499.0, 134900.0, "iPhone 15 Pro", "256 GB" },
                    { 2, "Asus", "Black", "Processor: IntelCore i3-1215U Processor 1.2 GHz (10M Cache, up to 4.4 GHz, 6 cores).", "Memory: 8GB DDR4 on board 3200MHz with | Storage: 512GB M.2 NVMe PCIe 4.0 SSD. ", "I/O Port: 1x USB 2.0 Type-A, 1x USB 3.2 Gen 1 Type-C, 2x USB 3.2 Gen 1 Type-A, 1x HDMI 1.4, 1x 3.5mm Combo Audio Jack, 1x DC-in.", 37990.0, 55990.0, "ASUS Vivobook 16", "512 GB SSD" },
                    { 3, "Samsung", "Dark Red", "The first Galaxy S with embedded S Pen. Write comfortably like pen on paper, turn quick notes into legible text and use Air Actions to control your phone remotely.", "5G Ready powered by Galaxy’s first 4nm processor. Our fastest, most powerful chip ever.", "The Dynamic AMOLED 2x display improves outdoor visibility with up to 1750 nits in peak brightness.* And the 120Hz adaptive refresh rate keeps the scroll smooth, adjusting to what's on screen for an optimized view.", 84499.0, 131900.0, "Samsung Galaxy S22 Ultra 5G", "256 GB" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
