// ReSharper disable All

using Microsoft.EntityFrameworkCore.Migrations;

namespace Boruc.LabEquip.Services.Equipment.Infrastructure.EF.Migrations
{
    public partial class renameBooksTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Equipments_books_BookId",
                schema: "equipment",
                table: "Equipments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_books",
                schema: "equipment",
                table: "books");

            migrationBuilder.RenameTable(
                name: "books",
                schema: "equipment",
                newName: "Books",
                newSchema: "equipment");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Books",
                schema: "equipment",
                table: "Books",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Equipments_Books_BookId",
                schema: "equipment",
                table: "Equipments",
                column: "BookId",
                principalSchema: "equipment",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Equipments_Books_BookId",
                schema: "equipment",
                table: "Equipments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Books",
                schema: "equipment",
                table: "Books");

            migrationBuilder.RenameTable(
                name: "Books",
                schema: "equipment",
                newName: "books",
                newSchema: "equipment");

            migrationBuilder.AddPrimaryKey(
                name: "PK_books",
                schema: "equipment",
                table: "books",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Equipments_books_BookId",
                schema: "equipment",
                table: "Equipments",
                column: "BookId",
                principalSchema: "equipment",
                principalTable: "books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
