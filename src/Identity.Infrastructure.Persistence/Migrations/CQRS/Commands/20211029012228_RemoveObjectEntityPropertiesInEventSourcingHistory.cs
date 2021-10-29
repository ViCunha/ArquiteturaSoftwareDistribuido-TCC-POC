using Microsoft.EntityFrameworkCore.Migrations;

namespace Identity.Infrastructure.Persistence.Migrations.CQRS.Commands
{
    public partial class RemoveObjectEntityPropertiesInEventSourcingHistory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ObjectEntity",
                table: "EventSourcingHistory");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ObjectEntity",
                table: "EventSourcingHistory",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
