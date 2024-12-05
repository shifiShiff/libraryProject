using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Library.Data.Migrations
{
    /// <inheritdoc />
    public partial class change1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "subscribers",
                columns: table => new
                {
                    SubscribeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    NumOfBorrows = table.Column<int>(type: "int", nullable: false),
                    NumOfCurrentBorrowing = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_subscribers", x => x.SubscribeId);
                });

            migrationBuilder.CreateTable(
                name: "borrows",
                columns: table => new
                {
                    BorrowCode = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BorrowDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BackDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SubscriberSubscribeId = table.Column<int>(type: "int", nullable: false),
                    BorrowBookCode = table.Column<int>(type: "int", nullable: false),
                    IsReturned = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_borrows", x => x.BorrowCode);
                    table.ForeignKey(
                        name: "FK_borrows_books_BorrowBookCode",
                        column: x => x.BorrowBookCode,
                        principalTable: "books",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_borrows_subscribers_SubscriberSubscribeId",
                        column: x => x.SubscriberSubscribeId,
                        principalTable: "subscribers",
                        principalColumn: "SubscribeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_borrows_BorrowBookCode",
                table: "borrows",
                column: "BorrowBookCode");

            migrationBuilder.CreateIndex(
                name: "IX_borrows_SubscriberSubscribeId",
                table: "borrows",
                column: "SubscriberSubscribeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "borrows");

            migrationBuilder.DropTable(
                name: "subscribers");
        }
    }
}
