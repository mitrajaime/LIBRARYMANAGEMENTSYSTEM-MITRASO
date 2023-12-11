using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LIBRARYMANAGEMENTSYSTEM_MITRASO.Migrations
{
    public partial class hehe : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BookId",
                table: "BorrowingRecordsDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_BorrowingRecordsDetails_BookId",
                table: "BorrowingRecordsDetails",
                column: "BookId");

            migrationBuilder.AddForeignKey(
                name: "FK_BorrowingRecordsDetails_Books_BookId",
                table: "BorrowingRecordsDetails",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "BookId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BorrowingRecordsDetails_Books_BookId",
                table: "BorrowingRecordsDetails");

            migrationBuilder.DropIndex(
                name: "IX_BorrowingRecordsDetails_BookId",
                table: "BorrowingRecordsDetails");

            migrationBuilder.DropColumn(
                name: "BookId",
                table: "BorrowingRecordsDetails");
        }
    }
}
