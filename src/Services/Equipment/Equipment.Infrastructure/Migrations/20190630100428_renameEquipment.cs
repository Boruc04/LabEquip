// ReSharper disable All

using Microsoft.EntityFrameworkCore.Migrations;

namespace Boruc.LabEquip.Services.Equipment.Infrastructure.Migrations
{
    public partial class renameEquipment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_equipments_books_BookId",
                schema: "equipment",
                table: "equipments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_equipments",
                schema: "equipment",
                table: "equipments");

            migrationBuilder.RenameTable(
                name: "equipments",
                schema: "equipment",
                newName: "Equipments",
                newSchema: "equipment");

            migrationBuilder.RenameIndex(
                name: "IX_equipments_BookId",
                schema: "equipment",
                table: "Equipments",
                newName: "IX_Equipments_BookId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Equipments",
                schema: "equipment",
                table: "Equipments",
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Equipments_books_BookId",
                schema: "equipment",
                table: "Equipments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Equipments",
                schema: "equipment",
                table: "Equipments");

            migrationBuilder.RenameTable(
                name: "Equipments",
                schema: "equipment",
                newName: "equipments",
                newSchema: "equipment");

            migrationBuilder.RenameIndex(
                name: "IX_Equipments_BookId",
                schema: "equipment",
                table: "equipments",
                newName: "IX_equipments_BookId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_equipments",
                schema: "equipment",
                table: "equipments",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_equipments_books_BookId",
                schema: "equipment",
                table: "equipments",
                column: "BookId",
                principalSchema: "equipment",
                principalTable: "books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
