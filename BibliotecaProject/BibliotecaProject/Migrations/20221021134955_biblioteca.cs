using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BibliotecaProject.Migrations
{
    public partial class biblioteca : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id_book = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PublishingHouse = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TypeOfBooks = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ISBN = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id_book);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ResidentialAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FiscalCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PositionBooks",
                columns: table => new
                {
                    Id_positionBook = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ID_book = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Room = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rack = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Shelf = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Place = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PositionBooks", x => x.Id_positionBook);
                    table.ForeignKey(
                        name: "FK_PositionBooks_Books_ID_book",
                        column: x => x.ID_book,
                        principalTable: "Books",
                        principalColumn: "Id_book",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IdentityCards",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ID_user = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Emissary = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExpirationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityCards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IdentityCards_Users_ID_user",
                        column: x => x.ID_user,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LoanQueues",
                columns: table => new
                {
                    Id_loanQueue = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ID_book = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ID_user = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoanQueues", x => x.Id_loanQueue);
                    table.ForeignKey(
                        name: "FK_LoanQueues_Books_ID_book",
                        column: x => x.ID_book,
                        principalTable: "Books",
                        principalColumn: "Id_book",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LoanQueues_Users_ID_user",
                        column: x => x.ID_user,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Loans",
                columns: table => new
                {
                    Id_loan = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RentalStartData = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RentalEndData = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ID_Book = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ID_user = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Loans", x => x.Id_loan);
                    table.ForeignKey(
                        name: "FK_Loans_Books_ID_Book",
                        column: x => x.ID_Book,
                        principalTable: "Books",
                        principalColumn: "Id_book",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Loans_Users_ID_user",
                        column: x => x.ID_user,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Parents",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ID_user = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Parents_Users_ID_user",
                        column: x => x.ID_user,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PurchaseQueues",
                columns: table => new
                {
                    Id_purchaseQueue = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ID_user = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PublishingHouse = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ISBN = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseQueues", x => x.Id_purchaseQueue);
                    table.ForeignKey(
                        name: "FK_PurchaseQueues_Users_ID_user",
                        column: x => x.ID_user,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_IdentityCards_ID_user",
                table: "IdentityCards",
                column: "ID_user");

            migrationBuilder.CreateIndex(
                name: "IX_LoanQueues_ID_book",
                table: "LoanQueues",
                column: "ID_book");

            migrationBuilder.CreateIndex(
                name: "IX_LoanQueues_ID_user",
                table: "LoanQueues",
                column: "ID_user");

            migrationBuilder.CreateIndex(
                name: "IX_Loans_ID_Book",
                table: "Loans",
                column: "ID_Book");

            migrationBuilder.CreateIndex(
                name: "IX_Loans_ID_user",
                table: "Loans",
                column: "ID_user");

            migrationBuilder.CreateIndex(
                name: "IX_Parents_ID_user",
                table: "Parents",
                column: "ID_user");

            migrationBuilder.CreateIndex(
                name: "IX_PositionBooks_ID_book",
                table: "PositionBooks",
                column: "ID_book");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseQueues_ID_user",
                table: "PurchaseQueues",
                column: "ID_user");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IdentityCards");

            migrationBuilder.DropTable(
                name: "LoanQueues");

            migrationBuilder.DropTable(
                name: "Loans");

            migrationBuilder.DropTable(
                name: "Parents");

            migrationBuilder.DropTable(
                name: "PositionBooks");

            migrationBuilder.DropTable(
                name: "PurchaseQueues");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
