using Microsoft.EntityFrameworkCore.Migrations;

namespace AnimalStore.Migrations
{
    public partial class AddedCountries : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CountryName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Capital = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Continent = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Climate = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Relief = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Countries");
        }
    }
}
