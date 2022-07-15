using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TopNews.Migrations
{
    public partial class Updated715c : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Author",
                table: "TopNewsItem",
                type: "TEXT",
                maxLength: 128,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<long>(
                name: "HackerNewsId",
                table: "TopNewsItem",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0L);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Author",
                table: "TopNewsItem");

            migrationBuilder.DropColumn(
                name: "HackerNewsId",
                table: "TopNewsItem");
        }
    }
}
