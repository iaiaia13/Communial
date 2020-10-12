using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.Data.EntityFrameworkCore.Metadata;

namespace NetCoreData.Migrations
{
    public partial class AddOfficesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Office",
                columns: table => new
                {
                    ID = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 255, nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    Image = table.Column<string>(nullable: true),
                    Capacity = table.Column<int>(nullable: false),
                    PricePerMonth = table.Column<double>(nullable: false),
                    PricePerDay = table.Column<double>(nullable: false),
                    PricePerQuarter = table.Column<double>(nullable: false),
                    PricePerYear = table.Column<double>(nullable: false),
                    Start = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Office", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "OfficeRenting",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    FromDate = table.Column<DateTime>(nullable: false),
                    ToDate = table.Column<DateTime>(nullable: false),
                    Type = table.Column<int>(nullable: false),
                    Price = table.Column<double>(nullable: false),
                    OfficeID = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OfficeRenting", x => x.ID);
                    table.ForeignKey(
                        name: "FK_OfficeRenting_Office_OfficeID",
                        column: x => x.OfficeID,
                        principalTable: "Office",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OfficeRenting_OfficeID",
                table: "OfficeRenting",
                column: "OfficeID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OfficeRenting");

            migrationBuilder.DropTable(
                name: "Office");
        }
    }
}
