using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NetCoreData.Migrations
{
    public partial class AddTokenToUserTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "User",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Token",
                table: "User",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "TokenExpirationTime",
                table: "User",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "User",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Token",
                table: "User");

            migrationBuilder.DropColumn(
                name: "TokenExpirationTime",
                table: "User");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "User");
        }
    }
}
