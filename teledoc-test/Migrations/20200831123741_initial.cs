using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace teledoc_test.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ITN = table.Column<string>(maxLength: 12, nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    LastUpdate = table.Column<DateTime>(nullable: false),
                    TypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerId);
                });

            migrationBuilder.CreateTable(
                name: "CustomerTypes",
                columns: table => new
                {
                    TypeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerTypes", x => x.TypeId);
                });

            migrationBuilder.CreateTable(
                name: "Founders",
                columns: table => new
                {
                    FounderId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ITN = table.Column<string>(maxLength: 12, nullable: false),
                    FirstName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false),
                    MiddleName = table.Column<string>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    LastUpdate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Founders", x => x.FounderId);
                });

            migrationBuilder.CreateTable(
                name: "CustomerFounder",
                columns: table => new
                {
                    CustomerId = table.Column<int>(nullable: false),
                    FounderId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerFounder", x => new { x.CustomerId, x.FounderId });
                    table.ForeignKey(
                        name: "FK_CustomerFounder_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomerFounder_Founders_FounderId",
                        column: x => x.FounderId,
                        principalTable: "Founders",
                        principalColumn: "FounderId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "CustomerTypes",
                columns: new[] { "TypeId", "Name" },
                values: new object[] { 1, "Индивидуальный предприниматель" });

            migrationBuilder.InsertData(
                table: "CustomerTypes",
                columns: new[] { "TypeId", "Name" },
                values: new object[] { 2, "Юридическое лицо" });

            migrationBuilder.CreateIndex(
                name: "IX_CustomerFounder_FounderId",
                table: "CustomerFounder",
                column: "FounderId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomerFounder");

            migrationBuilder.DropTable(
                name: "CustomerTypes");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Founders");
        }
    }
}
