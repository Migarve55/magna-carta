using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SharedDomain.Data.Migrations
{
    public partial class AddedDescriptionAndTypeFieldToProducts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Products",
                type: "TEXT",
                maxLength: 2000,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "Products",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Products");
        }
    }
}
