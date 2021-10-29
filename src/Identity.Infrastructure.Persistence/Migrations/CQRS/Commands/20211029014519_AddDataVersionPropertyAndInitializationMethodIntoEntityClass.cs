using Microsoft.EntityFrameworkCore.Migrations;

namespace Identity.Infrastructure.Persistence.Migrations.CQRS.Commands
{
    public partial class AddDataVersionPropertyAndInitializationMethodIntoEntityClass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "DataVersion",
                table: "TransactionProcessingControlHistory",
                type: "decimal(20,0)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "DataVersion",
                table: "EventSourcingHistory",
                type: "decimal(20,0)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "DataVersion",
                table: "Customers",
                type: "decimal(20,0)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataVersion",
                table: "TransactionProcessingControlHistory");

            migrationBuilder.DropColumn(
                name: "DataVersion",
                table: "EventSourcingHistory");

            migrationBuilder.DropColumn(
                name: "DataVersion",
                table: "Customers");
        }
    }
}
