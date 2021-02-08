using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DrinkUp.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tea",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TeaName = table.Column<string>(nullable: true),
                    Discription = table.Column<string>(nullable: true),
                    TeaType = table.Column<string>(nullable: true),
                    Organic = table.Column<bool>(nullable: false),
                    Caffene = table.Column<string>(nullable: false),
                    BrewType = table.Column<string>(nullable: true),
                    BrewTempC = table.Column<int>(nullable: false),
                    BrewTime = table.Column<decimal>(nullable: false),
                    Source = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tea", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tea");
        }
    }
}
