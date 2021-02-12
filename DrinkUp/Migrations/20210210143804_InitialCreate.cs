using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DrinkUp.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Coffee",
                columns: table => new
                {
                    CoffeeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CoffeeName = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    CoffeeType = table.Column<string>(nullable: true),
                    Caffiene = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coffee", x => x.CoffeeID);
                });

            migrationBuilder.CreateTable(
                name: "ColdCoffee",
                columns: table => new
                {
                    ColdCoffeeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ColdCoffeeType = table.Column<string>(nullable: true),
                    ColdCoffeeName = table.Column<string>(nullable: true),
                    Caffiene = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ColdCoffee", x => x.ColdCoffeeID);
                });

            migrationBuilder.CreateTable(
                name: "Frapuccino",
                columns: table => new
                {
                    FrapID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FrapType = table.Column<string>(nullable: true),
                    FrapName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Frapuccino", x => x.FrapID);
                });

            migrationBuilder.CreateTable(
                name: "HotCoffee",
                columns: table => new
                {
                    HotCoffeeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    HotCoffeeType = table.Column<string>(nullable: true),
                    HotCoffeeName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HotCoffee", x => x.HotCoffeeID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Coffee");

            migrationBuilder.DropTable(
                name: "ColdCoffee");

            migrationBuilder.DropTable(
                name: "Frapuccino");

            migrationBuilder.DropTable(
                name: "HotCoffee");
        }
    }
}
