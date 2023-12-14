using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LIBRARYMANAGEMENTSYSTEM_MITRASO.Migrations
{
    public partial class m : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BookCategory",
                columns: table => new
                {
                    BookCategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookCategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookCategory", x => x.BookCategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Borrower",
                columns: table => new
                {
                    BorrowerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StudentIdNo = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Course = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Borrower", x => x.BorrowerId);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StayLoggedIn = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    BookId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DatePublished = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BookCategoryId = table.Column<int>(type: "int", nullable: false),
                    IsBorrowed = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.BookId);
                    table.ForeignKey(
                        name: "FK_Books_BookCategory_BookCategoryId",
                        column: x => x.BookCategoryId,
                        principalTable: "BookCategory",
                        principalColumn: "BookCategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BorrowingRecords",
                columns: table => new
                {
                    BorrowingRecordsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateBorrowed = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReturnDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    BookId = table.Column<int>(type: "int", nullable: false),
                    BorrowerId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    HasPenalty = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BorrowingRecords", x => x.BorrowingRecordsId);
                    table.ForeignKey(
                        name: "FK_BorrowingRecords_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "BookId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BorrowingRecords_Borrower_BorrowerId",
                        column: x => x.BorrowerId,
                        principalTable: "Borrower",
                        principalColumn: "BorrowerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BorrowingRecords_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Penalty",
                columns: table => new
                {
                    PenaltyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PenaltyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    PenaltyDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsSettled = table.Column<bool>(type: "bit", nullable: false),
                    BorrowingRecordsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Penalty", x => x.PenaltyId);
                    table.ForeignKey(
                        name: "FK_Penalty_BorrowingRecords_BorrowingRecordsId",
                        column: x => x.BorrowingRecordsId,
                        principalTable: "BorrowingRecords",
                        principalColumn: "BorrowingRecordsId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Books_BookCategoryId",
                table: "Books",
                column: "BookCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_BorrowingRecords_BookId",
                table: "BorrowingRecords",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_BorrowingRecords_BorrowerId",
                table: "BorrowingRecords",
                column: "BorrowerId");

            migrationBuilder.CreateIndex(
                name: "IX_BorrowingRecords_UserId",
                table: "BorrowingRecords",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Penalty_BorrowingRecordsId",
                table: "Penalty",
                column: "BorrowingRecordsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Penalty");

            migrationBuilder.DropTable(
                name: "BorrowingRecords");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Borrower");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "BookCategory");
        }
    }
}
