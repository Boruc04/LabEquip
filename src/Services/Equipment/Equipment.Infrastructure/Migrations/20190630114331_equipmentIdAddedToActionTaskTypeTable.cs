// ReSharper disable All

using Microsoft.EntityFrameworkCore.Migrations;

namespace Boruc.LabEquip.Services.Equipment.Infrastructure.Migrations
{
    public partial class equipmentIdAddedToActionTaskTypeTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EquipmentId",
                schema: "equipment",
                table: "ActionTaskTypes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ActionTaskTypes_EquipmentId",
                schema: "equipment",
                table: "ActionTaskTypes",
                column: "EquipmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_ActionTaskTypes_Equipments_EquipmentId",
                schema: "equipment",
                table: "ActionTaskTypes",
                column: "EquipmentId",
                principalSchema: "equipment",
                principalTable: "Equipments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActionTaskTypes_Equipments_EquipmentId",
                schema: "equipment",
                table: "ActionTaskTypes");

            migrationBuilder.DropIndex(
                name: "IX_ActionTaskTypes_EquipmentId",
                schema: "equipment",
                table: "ActionTaskTypes");

            migrationBuilder.DropColumn(
                name: "EquipmentId",
                schema: "equipment",
                table: "ActionTaskTypes");
        }
    }
}
