using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace Identity.Infrastructure.Persistence.Migrations.CQRS.Commands
{
    public partial class AddObjectIdAndObjectEntityPropertiesInEventSourcingHistory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ObjectEntity",
                table: "EventSourcingHistory",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ObjectId",
                table: "EventSourcingHistory",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ObjectEntity",
                table: "EventSourcingHistory");

            migrationBuilder.DropColumn(
                name: "ObjectId",
                table: "EventSourcingHistory");
        }
    }
}
