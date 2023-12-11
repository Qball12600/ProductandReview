using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Products_ReviewsWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false),
                    Price = table.Column<double>(type: "double", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Text = table.Column<string>(type: "longtext", nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reviews_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "Wok Pan", 29.989999999999998 },
                    { 2, "Heavy Duty Spatula", 4.9900000000000002 },
                    { 3, "Rice Cooker", 49.990000000000002 },
                    { 4, "Bamboo Steamer", 14.99 },
                    { 5, "Chopsticks Set", 9.9900000000000002 }
                });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "Id", "ProductId", "Rating", "Text" },
                values: new object[,]
                {
                    { 1, 1, 5, "Great wok for stir-frying!" },
                    { 2, 2, 4, "Good quality product." },
                    { 3, 3, 5, "Makes perfect rice every time." },
                    { 4, 4, 4, "Perfect for steaming vegetables." },
                    { 5, 5, 4, "Nice chopsticks set for casual usage." },
                    { 6, 1, 3, "Decent wok, but could be better." },
                    { 7, 2, 2, "Melted on my stovetop." },
                    { 8, 3, 2, "Not very durable, broke after a few uses." },
                    { 9, 4, 3, "Steamer works well but could use more compartments." },
                    { 10, 5, 2, "Chopsticks are too slippery to hold properly." },
                    { 11, 1, 3, "Average wok, nothing special." },
                    { 12, 2, 3, "Standard spatula, everything you need." },
                    { 13, 3, 4, "Good value for the price." },
                    { 14, 4, 5, "Convenient for steaming various dishes." },
                    { 15, 5, 5, "Comfortable chopsticks to use." }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_ProductId",
                table: "Reviews",
                column: "ProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
