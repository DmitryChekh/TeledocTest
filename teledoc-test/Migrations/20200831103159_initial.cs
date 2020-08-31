using Microsoft.EntityFrameworkCore.Migrations;

namespace teledoc_test.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Founders",
                table: "Founders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Customers",
                table: "Customers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CustomerFounder",
                table: "CustomerFounder");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Founders");

            migrationBuilder.DropColumn(
                name: "CustomderId",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "CustomerFounder");

            migrationBuilder.AlterColumn<string>(
                name: "MiddleName",
                table: "Founders",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Founders",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ITN",
                table: "Founders",
                maxLength: 12,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Founders",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FounderId",
                table: "Founders",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Customers",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ITN",
                table: "Customers",
                maxLength: 12,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "CustomerId",
                table: "Customers",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Founders",
                table: "Founders",
                column: "FounderId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Customers",
                table: "Customers",
                column: "CustomerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CustomerFounder",
                table: "CustomerFounder",
                columns: new[] { "CustomerId", "FounderId" });

            migrationBuilder.CreateIndex(
                name: "IX_CustomerFounder_FounderId",
                table: "CustomerFounder",
                column: "FounderId");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerFounder_Customers_CustomerId",
                table: "CustomerFounder",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "CustomerId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerFounder_Founders_FounderId",
                table: "CustomerFounder",
                column: "FounderId",
                principalTable: "Founders",
                principalColumn: "FounderId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerFounder_Customers_CustomerId",
                table: "CustomerFounder");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomerFounder_Founders_FounderId",
                table: "CustomerFounder");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Founders",
                table: "Founders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Customers",
                table: "Customers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CustomerFounder",
                table: "CustomerFounder");

            migrationBuilder.DropIndex(
                name: "IX_CustomerFounder_FounderId",
                table: "CustomerFounder");

            migrationBuilder.DropColumn(
                name: "FounderId",
                table: "Founders");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "Customers");

            migrationBuilder.AlterColumn<string>(
                name: "MiddleName",
                table: "Founders",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Founders",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<int>(
                name: "ITN",
                table: "Founders",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 12);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Founders",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Founders",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<int>(
                name: "ITN",
                table: "Customers",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 12);

            migrationBuilder.AddColumn<int>(
                name: "CustomderId",
                table: "Customers",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "CustomerFounder",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Founders",
                table: "Founders",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Customers",
                table: "Customers",
                column: "CustomderId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CustomerFounder",
                table: "CustomerFounder",
                column: "Id");
        }
    }
}
