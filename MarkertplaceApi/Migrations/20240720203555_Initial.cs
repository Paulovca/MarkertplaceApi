using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MarkertplaceApi.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    price = table.Column<double>(type: "float", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    quantityAvailable = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.id);
                });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "id", "description", "name", "price", "quantityAvailable" },
                values: new object[,]
                {
                    { 1, "It takes photos", "Camera", 18.989999999999998, 100 },
                    { 2, "Best audio quality", "Microphone", 30.989999999999998, 10 },
                    { 3, "Mechanical switches", "Keyboard", 10.99, 30 },
                    { 4, "Gamer mouse", "Mouse", 5.9900000000000002, 200 },
                    { 5, "Good for work", "Notebook", 999.99000000000001, 22 },
                    { 6, "Good for drawing", "Tablet", 180.99000000000001, 1 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Items");
        }
    }
}
