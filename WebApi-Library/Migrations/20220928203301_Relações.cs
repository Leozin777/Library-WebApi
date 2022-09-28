using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi_Library.Migrations
{
    public partial class Relações : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_books_requests_RequestId",
                table: "books");

            migrationBuilder.AddColumn<int>(
                name: "BookId",
                table: "requests",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_Book",
                table: "books",
                column: "RequestId",
                principalTable: "requests",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Requests_Book",
                table: "books");

            migrationBuilder.DropColumn(
                name: "BookId",
                table: "requests");

            migrationBuilder.AddForeignKey(
                name: "FK_books_requests_RequestId",
                table: "books",
                column: "RequestId",
                principalTable: "requests",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
