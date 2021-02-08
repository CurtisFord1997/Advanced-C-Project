using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DrinkUp.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tea",
                columns: table => new
                {
                    TeaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TeaName = table.Column<string>(nullable: true),
                    Discription = table.Column<string>(nullable: true),
                    TeaType = table.Column<string>(nullable: true),
                    TeaBrand = table.Column<string>(nullable: true),
                    Organic = table.Column<bool>(nullable: false),
                    Caffene = table.Column<string>(nullable: false),
                    BrewType = table.Column<string>(nullable: true),
                    BrewTempC = table.Column<int>(nullable: false),
                    BrewTime = table.Column<decimal>(nullable: false),
                    Source = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tea", x => x.TeaID);
                });

            migrationBuilder.CreateTable(
                name: "TeaIngredient",
                columns: table => new
                {
                    TeaIngredientID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IngredientName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeaIngredient", x => x.TeaIngredientID);
                });

            migrationBuilder.CreateTable(
                name: "TeaIngredientLink",
                columns: table => new
                {
                    TeaId = table.Column<int>(nullable: false),
                    TeaIngredientID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeaIngredientLink", x => new { x.TeaId, x.TeaIngredientID });
                });

            migrationBuilder.CreateTable(
                name: "TeaStore",
                columns: table => new
                {
                    TeaStoreID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Url = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeaStore", x => x.TeaStoreID);
                });

            migrationBuilder.CreateTable(
                name: "TeaStoreLink",
                columns: table => new
                {
                    TeaId = table.Column<int>(nullable: false),
                    TeaStoreId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeaStoreLink", x => new { x.TeaId, x.TeaStoreId });
                });

            migrationBuilder.CreateTable(
                name: "TeaTags",
                columns: table => new
                {
                    TeaTagID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Tag = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeaTags", x => x.TeaTagID);
                });

            migrationBuilder.CreateTable(
                name: "TeaTagsLink",
                columns: table => new
                {
                    TeaTagID = table.Column<int>(nullable: false),
                    TeaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeaTagsLink", x => new { x.TeaId, x.TeaTagID });
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tea");

            migrationBuilder.DropTable(
                name: "TeaIngredient");

            migrationBuilder.DropTable(
                name: "TeaIngredientLink");

            migrationBuilder.DropTable(
                name: "TeaStore");

            migrationBuilder.DropTable(
                name: "TeaStoreLink");

            migrationBuilder.DropTable(
                name: "TeaTags");

            migrationBuilder.DropTable(
                name: "TeaTagsLink");
        }
    }
}
