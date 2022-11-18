using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CatalogAPI.Migrations
{
    public partial class PopulateProducts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
                "Insert into Products(Name, Description, Price, ImageUrl, Inventory, RegistrationDate, CategoryId) values " +
                "row('Conke', '500ml', 5.99, 'conke.jpg', 10, now(), 1)," +
                "row('Chicken Nugger', '500g', 12.99, 'chicnug.jpg', 3, now(), 2)," +
                "row('Brownie', 'every meal 200g', 800.00, 'brownie.jpg', 8, now(), 3)"
                );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Delete from Products");
        }
    }
}
