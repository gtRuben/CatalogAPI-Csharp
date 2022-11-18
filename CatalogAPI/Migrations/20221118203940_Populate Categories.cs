using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CatalogAPI.Migrations
{
    public partial class PopulateCategories : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
                "Insert into Categories(Name, ImageUrl) values " +
                "row('Drinks','drinks.jpg')," +
                "row('Snacks', 'snacks.jpg')," +
                "row('Desserts', 'desserts.jpg')"
                );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Delete from Categories");
        }
    }
}
