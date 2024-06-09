using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APBDKolokwium.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "apbd");

            migrationBuilder.CreateTable(
                name: "Client",
                schema: "apbd",
                columns: table => new
                {
                    IdClient = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client", x => x.IdClient);
                });

            migrationBuilder.CreateTable(
                name: "Subscription",
                schema: "apbd",
                columns: table => new
                {
                    IdSubscription = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    RenewalPeriod = table.Column<int>(type: "int", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Price = table.Column<decimal>(type: "Money", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subscription", x => x.IdSubscription);
                });

            migrationBuilder.CreateTable(
                name: "Discount",
                schema: "apbd",
                columns: table => new
                {
                    IdDiscount = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<int>(type: "int", nullable: false),
                    DateFrom = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateTo = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdClient = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Discount", x => x.IdDiscount);
                    table.ForeignKey(
                        name: "FK_Discount_Client_IdClient",
                        column: x => x.IdClient,
                        principalSchema: "apbd",
                        principalTable: "Client",
                        principalColumn: "IdClient",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Payment",
                schema: "apbd",
                columns: table => new
                {
                    IdPayment = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Value = table.Column<decimal>(type: "Money", nullable: false),
                    IdClient = table.Column<int>(type: "int", nullable: false),
                    IdSubscription = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payment", x => x.IdPayment);
                    table.ForeignKey(
                        name: "FK_Payment_Client_IdClient",
                        column: x => x.IdClient,
                        principalSchema: "apbd",
                        principalTable: "Client",
                        principalColumn: "IdClient");
                    table.ForeignKey(
                        name: "FK_Payment_Subscription_IdSubscription",
                        column: x => x.IdSubscription,
                        principalSchema: "apbd",
                        principalTable: "Subscription",
                        principalColumn: "IdSubscription");
                });

            migrationBuilder.CreateTable(
                name: "Sale",
                schema: "apbd",
                columns: table => new
                {
                    IdSale = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdClient = table.Column<int>(type: "int", nullable: false),
                    IdSubscription = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sale", x => x.IdSale);
                    table.ForeignKey(
                        name: "FK_Sale_Client_IdClient",
                        column: x => x.IdClient,
                        principalSchema: "apbd",
                        principalTable: "Client",
                        principalColumn: "IdClient");
                    table.ForeignKey(
                        name: "FK_Sale_Subscription_IdSubscription",
                        column: x => x.IdSubscription,
                        principalSchema: "apbd",
                        principalTable: "Subscription",
                        principalColumn: "IdSubscription");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Discount_IdClient",
                schema: "apbd",
                table: "Discount",
                column: "IdClient");

            migrationBuilder.CreateIndex(
                name: "IX_Payment_IdClient",
                schema: "apbd",
                table: "Payment",
                column: "IdClient");

            migrationBuilder.CreateIndex(
                name: "IX_Payment_IdSubscription",
                schema: "apbd",
                table: "Payment",
                column: "IdSubscription");

            migrationBuilder.CreateIndex(
                name: "IX_Sale_IdClient",
                schema: "apbd",
                table: "Sale",
                column: "IdClient");

            migrationBuilder.CreateIndex(
                name: "IX_Sale_IdSubscription",
                schema: "apbd",
                table: "Sale",
                column: "IdSubscription");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Discount",
                schema: "apbd");

            migrationBuilder.DropTable(
                name: "Payment",
                schema: "apbd");

            migrationBuilder.DropTable(
                name: "Sale",
                schema: "apbd");

            migrationBuilder.DropTable(
                name: "Client",
                schema: "apbd");

            migrationBuilder.DropTable(
                name: "Subscription",
                schema: "apbd");
        }
    }
}
