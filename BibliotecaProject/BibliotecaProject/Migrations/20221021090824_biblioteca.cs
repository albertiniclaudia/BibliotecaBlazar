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
                    Title = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Author = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PublishingHouse = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    NumberOfCopy = table.Column<int>(type: "int", nullable: false),
                    TypeOfBooks = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
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
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ResidentialAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FiscalCode = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
                    Room = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    Rack = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    Shelf = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    Place = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    ID_book = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
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
                    Id_user = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Id_parent = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Emissary = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExpirationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityCards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IdentityCards_Users_Id_user",
                        column: x => x.Id_user,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Loan",
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
                    table.PrimaryKey("PK_Loan", x => x.Id_loan);
                    table.ForeignKey(
                        name: "FK_Loan_Books_ID_Book",
                        column: x => x.ID_Book,
                        principalTable: "Books",
                        principalColumn: "Id_book",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Loan_Users_ID_user",
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
                name: "Parents",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Id_user = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Parents_Users_Id_user",
                        column: x => x.Id_user,
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
                    Title = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Author = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    PublishingHouse = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ISBN = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: true)
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
                name: "IX_IdentityCards_Id_user",
                table: "IdentityCards",
                column: "Id_user");

            migrationBuilder.CreateIndex(
                name: "IX_Loan_ID_Book",
                table: "Loan",
                column: "ID_Book");

            migrationBuilder.CreateIndex(
                name: "IX_Loan_ID_user",
                table: "Loan",
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
                name: "IX_Parents_Id_user",
                table: "Parents",
                column: "Id_user");

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
                name: "Loan");

            migrationBuilder.DropTable(
                name: "LoanQueues");

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
