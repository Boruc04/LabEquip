using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Boruc.LabEquip.Services.Equipment.Infrastructure.EF.Migrations
{
    public partial class ActionTypeEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateSequence(
                name: "actionTaskTypesSeq",
                schema: "equipment",
                incrementBy: 10);

            migrationBuilder.CreateTable(
                name: "TaskFrequencies",
                schema: "equipment",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false, defaultValue: 1),
                    Name = table.Column<string>(maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskFrequencies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TaskTypes",
                schema: "equipment",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false, defaultValue: 1),
                    Name = table.Column<string>(maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ActionTaskTypes",
                schema: "equipment",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    TaskTypeId = table.Column<int>(nullable: false),
                    TaskFrequencyId = table.Column<int>(nullable: false),
                    FirstOccurrence = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActionTaskTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ActionTaskTypes_TaskFrequencies_TaskFrequencyId",
                        column: x => x.TaskFrequencyId,
                        principalSchema: "equipment",
                        principalTable: "TaskFrequencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ActionTaskTypes_TaskTypes_TaskTypeId",
                        column: x => x.TaskTypeId,
                        principalSchema: "equipment",
                        principalTable: "TaskTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ActionTaskTypes_TaskFrequencyId",
                schema: "equipment",
                table: "ActionTaskTypes",
                column: "TaskFrequencyId");

            migrationBuilder.CreateIndex(
                name: "IX_ActionTaskTypes_TaskTypeId",
                schema: "equipment",
                table: "ActionTaskTypes",
                column: "TaskTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActionTaskTypes",
                schema: "equipment");

            migrationBuilder.DropTable(
                name: "TaskFrequencies",
                schema: "equipment");

            migrationBuilder.DropTable(
                name: "TaskTypes",
                schema: "equipment");

            migrationBuilder.DropSequence(
                name: "actionTaskTypesSeq",
                schema: "equipment");
        }
    }
}
