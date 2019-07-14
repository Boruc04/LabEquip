using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Boruc.LabEquip.Services.Equipment.Infrastructure.EF.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "equipment");

            migrationBuilder.CreateSequence(
                name: "bookseq",
                schema: "equipment",
                incrementBy: 10);

            migrationBuilder.CreateSequence(
                name: "equipmentseq",
                schema: "equipment",
                incrementBy: 10);

            migrationBuilder.CreateTable(
                name: "books",
                schema: "equipment",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_books", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "equipments",
                schema: "equipment",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    AddedOnUTC = table.Column<DateTime>(nullable: false),
                    BookId = table.Column<int>(nullable: true),
                    Name = table.Column<string>(nullable: false),
                    Number = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_equipments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_equipments_books_BookId",
                        column: x => x.BookId,
                        principalSchema: "equipment",
                        principalTable: "books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_equipments_BookId",
                schema: "equipment",
                table: "equipments",
                column: "BookId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "equipments",
                schema: "equipment");

            migrationBuilder.DropTable(
                name: "books",
                schema: "equipment");

            migrationBuilder.DropSequence(
                name: "bookseq",
                schema: "equipment");

            migrationBuilder.DropSequence(
                name: "equipmentseq",
                schema: "equipment");
        }
    }
}
