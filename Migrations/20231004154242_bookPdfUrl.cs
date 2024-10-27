using Microsoft.EntityFrameworkCore.Migrations;

namespace BookStoreWebApp.Migrations
{
    public partial class bookPdfUrl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BookPdfURL",
                table: "Books",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BookPdfURL",
                table: "Books");
        }
    }
}
