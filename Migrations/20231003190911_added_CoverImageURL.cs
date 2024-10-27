using Microsoft.EntityFrameworkCore.Migrations;

namespace BookStoreWebApp.Migrations
{
    public partial class added_CoverImageURL : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CoverImageURL",
                table: "Books",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CoverImageURL",
                table: "Books");
        }
    }
}
