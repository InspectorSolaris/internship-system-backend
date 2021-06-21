using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Internship.DAL.Migrations
{
    public partial class FixPriorityRelations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PriorityCompanies_AspNetUsers_CompanyId",
                table: "PriorityCompanies");

            migrationBuilder.DropForeignKey(
                name: "FK_PriorityCompanies_Positions_PositionId",
                table: "PriorityCompanies");

            migrationBuilder.DropForeignKey(
                name: "FK_PriorityStudents_AspNetUsers_CompanyId",
                table: "PriorityStudents");

            migrationBuilder.DropIndex(
                name: "IX_PriorityCompanies_CompanyId",
                table: "PriorityCompanies");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "PriorityCompanies");

            migrationBuilder.RenameColumn(
                name: "CompanyId",
                table: "PriorityStudents",
                newName: "PositionId");

            migrationBuilder.RenameIndex(
                name: "IX_PriorityStudents_CompanyId",
                table: "PriorityStudents",
                newName: "IX_PriorityStudents_PositionId");

            migrationBuilder.AlterColumn<Guid>(
                name: "PositionId",
                table: "PriorityCompanies",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PriorityCompanies_Positions_PositionId",
                table: "PriorityCompanies",
                column: "PositionId",
                principalTable: "Positions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PriorityStudents_Positions_PositionId",
                table: "PriorityStudents",
                column: "PositionId",
                principalTable: "Positions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PriorityCompanies_Positions_PositionId",
                table: "PriorityCompanies");

            migrationBuilder.DropForeignKey(
                name: "FK_PriorityStudents_Positions_PositionId",
                table: "PriorityStudents");

            migrationBuilder.RenameColumn(
                name: "PositionId",
                table: "PriorityStudents",
                newName: "CompanyId");

            migrationBuilder.RenameIndex(
                name: "IX_PriorityStudents_PositionId",
                table: "PriorityStudents",
                newName: "IX_PriorityStudents_CompanyId");

            migrationBuilder.AlterColumn<Guid>(
                name: "PositionId",
                table: "PriorityCompanies",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddColumn<Guid>(
                name: "CompanyId",
                table: "PriorityCompanies",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_PriorityCompanies_CompanyId",
                table: "PriorityCompanies",
                column: "CompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_PriorityCompanies_AspNetUsers_CompanyId",
                table: "PriorityCompanies",
                column: "CompanyId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PriorityCompanies_Positions_PositionId",
                table: "PriorityCompanies",
                column: "PositionId",
                principalTable: "Positions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PriorityStudents_AspNetUsers_CompanyId",
                table: "PriorityStudents",
                column: "CompanyId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
