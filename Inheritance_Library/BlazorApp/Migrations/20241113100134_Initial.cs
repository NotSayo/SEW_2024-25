using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorApp.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PERSONS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FIRST_NAME = table.Column<string>(type: "TEXT", nullable: true),
                    LAST_NAME = table.Column<string>(type: "TEXT", nullable: true),
                    DATE_OF_BIRTH = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PERSONS", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AUTHORS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Biography = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AUTHORS", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AUTHORS_PERSONS_Id",
                        column: x => x.Id,
                        principalTable: "PERSONS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CUSTOMERS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MembershipDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CUSTOMERS", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CUSTOMERS_PERSONS_Id",
                        column: x => x.Id,
                        principalTable: "PERSONS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LIBRARIANS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    EmployeeId = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LIBRARIANS", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LIBRARIANS_PERSONS_Id",
                        column: x => x.Id,
                        principalTable: "PERSONS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ITEMS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TITLE = table.Column<string>(type: "TEXT", nullable: true),
                    AUTHOR = table.Column<string>(type: "TEXT", nullable: true),
                    PUBLISHED_DATE = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ISBN = table.Column<string>(type: "TEXT", nullable: true),
                    AVAILABLE_COPIES = table.Column<int>(type: "INTEGER", nullable: false),
                    AuthorId = table.Column<int>(type: "INTEGER", nullable: false),
                    ITEM_TYPE = table.Column<string>(type: "TEXT", maxLength: 21, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ITEMS", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ITEMS_AUTHORS_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "AUTHORS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BookDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false),
                    TotalCopies = table.Column<int>(type: "INTEGER", nullable: false),
                    BorrowedCopies = table.Column<int>(type: "INTEGER", nullable: false),
                    AvailableCopies = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BookDetails_ITEMS_Id",
                        column: x => x.Id,
                        principalTable: "ITEMS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BookManagement",
                columns: table => new
                {
                    CustomerId = table.Column<int>(type: "INTEGER", nullable: false),
                    BookId = table.Column<int>(type: "INTEGER", nullable: false),
                    LibrarianId = table.Column<int>(type: "INTEGER", nullable: false),
                    LoanDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DueDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ReturnLibrarianId = table.Column<int>(type: "INTEGER", nullable: true),
                    ReturnDate = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookManagement", x => new { x.CustomerId, x.BookId, x.LibrarianId });
                    table.ForeignKey(
                        name: "FK_BookManagement_CUSTOMERS_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "CUSTOMERS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookManagement_ITEMS_BookId",
                        column: x => x.BookId,
                        principalTable: "ITEMS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookManagement_LIBRARIANS_LibrarianId",
                        column: x => x.LibrarianId,
                        principalTable: "LIBRARIANS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookManagement_LIBRARIANS_ReturnLibrarianId",
                        column: x => x.ReturnLibrarianId,
                        principalTable: "LIBRARIANS",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookManagement_BookId",
                table: "BookManagement",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_BookManagement_LibrarianId",
                table: "BookManagement",
                column: "LibrarianId");

            migrationBuilder.CreateIndex(
                name: "IX_BookManagement_ReturnLibrarianId",
                table: "BookManagement",
                column: "ReturnLibrarianId");

            migrationBuilder.CreateIndex(
                name: "IX_ITEMS_AuthorId",
                table: "ITEMS",
                column: "AuthorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookDetails");

            migrationBuilder.DropTable(
                name: "BookManagement");

            migrationBuilder.DropTable(
                name: "CUSTOMERS");

            migrationBuilder.DropTable(
                name: "ITEMS");

            migrationBuilder.DropTable(
                name: "LIBRARIANS");

            migrationBuilder.DropTable(
                name: "AUTHORS");

            migrationBuilder.DropTable(
                name: "PERSONS");
        }
    }
}
