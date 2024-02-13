using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EFCoreQueryBug.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Contact",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contact", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Statements",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TransactionId = table.Column<int>(type: "int", nullable: false),
                    ContactId = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Statements_Contact_ContactId",
                        column: x => x.ContactId,
                        principalTable: "Contact",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Statements_Transactions_TransactionId",
                        column: x => x.TransactionId,
                        principalTable: "Transactions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Contact",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Contact 1" },
                    { 2, "Contact 2" },
                    { 3, "Contact 3" },
                    { 4, "Contact 4" },
                    { 5, "Contact 5" },
                    { 6, "Contact 6" }
                });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Transaction 1" },
                    { 2, "Transaction 2" },
                    { 3, "Transaction 3" },
                    { 4, "Transaction 4" }
                });

            migrationBuilder.InsertData(
                table: "Statements",
                columns: new[] { "Id", "ContactId", "Name", "TransactionId", "Type" },
                values: new object[,]
                {
                    { 1, 1, "Statement 1", 1, "Client" },
                    { 2, 3, "Statement 2", 1, "Model" },
                    { 3, 5, "Statement 3", 1, "Agency" },
                    { 4, 1, "Statement 4", 2, "Client" },
                    { 5, 4, "Statement 5", 2, "Model" },
                    { 6, 6, "Statement 6", 2, "Agency" },
                    { 7, 2, "Statement 7", 3, "Client" },
                    { 8, 3, "Statement 8", 3, "Model" },
                    { 9, 6, "Statement 9", 3, "Agency" },
                    { 10, 2, "Statement 1", 4, "Client" },
                    { 11, 4, "Statement 2", 4, "Model" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Statements_ContactId",
                table: "Statements",
                column: "ContactId");

            migrationBuilder.CreateIndex(
                name: "IX_Statements_TransactionId",
                table: "Statements",
                column: "TransactionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Statements");

            migrationBuilder.DropTable(
                name: "Contact");

            migrationBuilder.DropTable(
                name: "Transactions");
        }
    }
}
